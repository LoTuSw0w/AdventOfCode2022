using System.Collections;
using System.Runtime.InteropServices;

namespace AdventOfCode2022;

public class Solutions
{
    /*=========================== Day 1 /*===========================*/
    /*Solving this with simple brute force would be too easy.
     Therefore, I tried to write a sollution in LINQ*/

    public static int Day1(string filePath)
    {
        var elvesData = File.ReadAllText(filePath);

        var result = elvesData
            .Split("\n\n") /*Now we have a list of string, each string in the list contains the calories that an elf carries*/
            .Select(stringWithNewLineChar => stringWithNewLineChar .Split("\n")) /*Turn the string represent the total calories of each elf into a list by spliting based on the new line character*/
            .Select(arrayOfCalories => arrayOfCalories.Select(singleCalories => Convert.ToInt32(singleCalories)).Sum()) /*Convert each calories string into an integer, then get the sum of the list*/
            .OrderByDescending(values => values)
            .First();

        return result;
    }

    public static int Day2(string filePath)
    {
        Hashtable RPSMapping = new Hashtable();
        RPSMapping.Add("B X", 1);
        RPSMapping.Add("C Y", 2);
        RPSMapping.Add("A Z", 3);
        RPSMapping.Add("A X", 4);
        RPSMapping.Add("B Y", 5);
        RPSMapping.Add("C Z", 6);
        RPSMapping.Add("C X", 7);
        RPSMapping.Add("A Y", 8);
        RPSMapping.Add("B Z", 9);

        var elvesData = File.ReadAllText(filePath);
        var result = elvesData.Split("\n")
        .Select(data => RPSMapping[data])
        .Sum(x => Convert.ToInt32(x));
        return result;
    }

    
}
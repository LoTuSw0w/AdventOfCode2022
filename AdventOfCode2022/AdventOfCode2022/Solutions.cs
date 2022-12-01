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
            .Select(stringWithNewLineChar =>
                stringWithNewLineChar
                    .Split("\n")) /*Turn the string represent the total calories of each elf into a list by spliting based on the new line character*/
            .Select(arrayOfCalories => arrayOfCalories.Select(calory => Convert.ToInt32(calory)).Sum())
            .OrderByDescending(values => values)
            .First();

        return result;
    }

    
}
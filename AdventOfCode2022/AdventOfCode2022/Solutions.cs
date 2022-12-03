using System.Collections;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace AdventOfCode2022;

public class Solutions
{
    /*=========================== Day 1 ===========================*/
    /*Solving this with simple brute force would be too easy.
     Therefore, I tried to write a solution in LINQ*/

    public static int Day1(string filePath, int numberOfTopElves)
    {
        var elvesData = File.ReadAllText(filePath);

        var result = elvesData
            .Split("\n\n") /*Now we have a list of string, each string in the list contains the calories that an elf carries*/
            .Select(stringWithNewLineChar => stringWithNewLineChar .Split("\n")) /*Turn the string represent the total calories of each elf into a list by spliting based on the new line character*/
            .Select(arrayOfCalories => arrayOfCalories.Select(singleCalories => Convert.ToInt32(singleCalories)).Sum()) /*Convert each calories string into an integer, then get the sum of the list*/
            .OrderByDescending(values => values)
            .Take(numberOfTopElves).Sum();

        return result;
    }

    /*=========================== Day 2 ===========================*/

    public static int Day2_part1(string filePath)
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
        var result = elvesData.Split("\r\n")
        .Select(data => RPSMapping[data])
        .Sum(x => Convert.ToInt32(x));
        return result;
    }
    /*(1 for Rock A, 2 for Paper B , and 3 for Scissors C)*/
    /*(0 if you lost, 3 if the round was a draw, and 6 if you won)*/
    public static int Day2_part2(string filePath)
    {
        Hashtable RPSMapping = new Hashtable();
        RPSMapping.Add("A X", 3);
        RPSMapping.Add("A Y", 4);
        RPSMapping.Add("A Z", 8);
        RPSMapping.Add("B X", 1);
        RPSMapping.Add("B Y", 5);
        RPSMapping.Add("B Z", 9);
        RPSMapping.Add("C X", 2);
        RPSMapping.Add("C Y", 6);
        RPSMapping.Add("C Z", 7);

        var elvesData = File.ReadAllText(filePath);
        var result = elvesData.Split("\r\n")
            .Select(data => RPSMapping[data])
            .Sum(x => Convert.ToInt32(x));
        return result;
    }

    /*=========================== Day 3 ===========================*/
    public static char GetMatchingChar(string a, string b)
    {
        char toReturn = ' ';
        foreach (char c in a)
        {
            if (b.Contains(c))
            {
                toReturn = c;
            }
        }

        return toReturn;
    }

    public static int CalculatePriority(char a)
    {
        if (Char.IsUpper(a))
        {
            return a - 'A' + 27;
        }
        else
        {
            return a - 'a' + 1;
        }
    }

    public static int Day3_part1(string filePath)
    {
        var elvesData = File.ReadAllText(filePath)
            .Split("\n")
            .Select(s =>
                Solutions.GetMatchingChar(s.Substring(0, s.Length / 2), s.Substring(s.Length / 2, s.Length / 2)))
            .Select(s => Solutions.CalculatePriority(s))
            .Sum();

        return elvesData;
    }

    public static int Day3_part2(string filePath)
    {
        var elvesData = File.ReadAllText(filePath)
            .Split("\n")
            .Chunk(3)
            .Select(s => s[0].Intersect(s[1].Intersect(s[2])).First())
            .Select(s => Solutions.CalculatePriority(s))
            .Sum();
        return elvesData;
    }

}
using Pzl.Common;
using Pzl.Tools.Strings;
using Spectre.Console;

namespace Pzl.Everybody.Puzzles.Everybody05;

[Name("Pseudo-Random Clap Dance")]
public class Everybody05 : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var result = RunPart1(input, 10);
        return new PuzzleResult(result, "950b4825d76ba062befffe8cb9a0be2c");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var result = RunPart2(input, 2024);
        return new PuzzleResult(result, "6b4db5dbf70faa6e08d4a645d6d2b4cc");
    }

    protected override PuzzleResult RunPart3(string input)
    {
        var result = Part3(input);
        return new PuzzleResult(result, "5789564a5b01f519e8eddcfc0f7aa6a2");
    }

    public static string RunPart1(string input, int rounds)
    {
        var columns = ParseDance(input);
        var result = columns.DanceRounds(rounds);
        
        return result;
    }
    
    public static long RunPart2(string input, int target)
    {
        var columns = ParseDance(input);
        var result = columns.DanceUntilRepeatCount(target);
        
        return result;
    }
    
    public static long Part3(string input)
    {
        var columns = ParseDance(input);
        var result = columns.DanceForever();
        
        return result;
    }

    private static ClapDance ParseDance(string input)
    {
        var columns = new List<List<int>>();
        var rows = input.Split(LineBreaks.Single);
        foreach (var row in rows)
        {
            var nums = row.Split(' ').Select(int.Parse).ToList();
            for (var i = 0; i < nums.Count; i++)
            {
                if(columns.Count <= i)
                    columns.Add([]);
                columns[i].Add(nums[i]);
            }
        }

        return new ClapDance(columns);
    }
}
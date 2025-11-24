using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202405;

[Name("Pseudo-Random Clap Dance")]
public class Ece202405 : EverybodyEventPuzzle
{
    public PuzzleResult RunPart1(string input) => new(RunPart1(input, 10), "950b4825d76ba062befffe8cb9a0be2c");
    public PuzzleResult RunPart2(string input) => new(RunPart2(input, 2024), "6b4db5dbf70faa6e08d4a645d6d2b4cc");
    public PuzzleResult RunPart3(string input) => new(ParseDance(input).DanceForever(), "5789564a5b01f519e8eddcfc0f7aa6a2");

    public string RunPart1(string input, int rounds)
    {
        var columns = ParseDance(input);
        var result = columns.DanceRounds(rounds);
        
        return result;
    }
    
    public long RunPart2(string input, int target)
    {
        var columns = ParseDance(input);
        var result = columns.DanceUntilRepeatCount(target);
        
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
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202405;

[Name("Pseudo-Random Clap Dance")]
public class Ece202405 : EverybodyEventPuzzle
{
    [Puzzle("950b4825d76ba062befffe8cb9a0be2c")]
    public string Part1(string input) => SolvePart1(input, 10);
    
    [Puzzle("6b4db5dbf70faa6e08d4a645d6d2b4cc")]
    public long Part2(string input) => SolvePart2(input, 2024);
    
    [Puzzle("5789564a5b01f519e8eddcfc0f7aa6a2")]
    public long Part3(string input) => ParseDance(input).DanceForever();

    public string SolvePart1(string input, int rounds) => ParseDance(input).DanceRounds(rounds);
    public long SolvePart2(string input, int target) => ParseDance(input).DanceUntilRepeatCount(target);

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
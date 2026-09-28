using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Corruption Checksum")]
public class Aoc201702 : AocPuzzle
{
    [Puzzle("d61d3967c55f3affc9cb3db5d9bb4c39")]
    public int Part1(string input) => Parse(input).Sum(row => row.Max() - row.Min());

    [Puzzle("cde27fe58ccb82229c3aa108e113d5bb")]
    public int Part2(string input)
    {
        var numberRows = Parse(input);
        var checksum = 0;
        foreach (var row in numberRows)
        {
            foreach (var num1 in row)
            {
                foreach (var num2 in row)
                {
                    if (num1 != num2 && num1 % num2 == 0)
                    {
                        checksum += num1 / num2;
                    }
                }
            }
        }

        return checksum;
    }
    
    private static int[][] Parse(string input) => 
        input.Split(LineBreaks.Single).Select(Numbers.IntsFromString).ToArray();
}
using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202309;

[Name("Mirage Maintenance")]
public class Aoc202309 : AocPuzzle
{
    [Puzzle("42abec426a1f1903197aaf0635b6a29a")]
    public long Part1(string input) => input.Split(LineBreaks.Single).Select(FindNextNumber).Sum();
    
    [Puzzle("652e203bd80c5889b310a0a8efdb2301")]
    public long Part2(string input) => input.Split(LineBreaks.Single).Select(FindPrevNumber).Sum();

    private static long FindNextNumber(string input) => Sequence.Next(ParseNumbers(input));
    private static long FindPrevNumber(string input) => Sequence.Previous(ParseNumbers(input));
    private static IEnumerable<long> ParseNumbers(string input) => input.Split(' ').Select(long.Parse);
}

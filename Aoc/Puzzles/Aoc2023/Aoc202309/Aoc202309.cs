using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202309;

[Name("Mirage Maintenance")]
public class Aoc202309 : AocPuzzle
{
    [Puzzle("42abec426a1f1903197aaf0635b6a29a")]
    public PuzzleResult Part1(string input) => new(SolvePart1(input));
    
    [Puzzle("652e203bd80c5889b310a0a8efdb2301")]
    public PuzzleResult Part2(string input) => new(SolvePart2(input));
    
    public static long SolvePart1(string input) => input.Split(LineBreaks.Single).Select(FindNextNumber).Sum();
    public static long SolvePart2(string input) => input.Split(LineBreaks.Single).Select(FindPrevNumber).Sum();
    public static long FindNextNumber(string input) => Sequence.Next(ParseNumbers(input));
    public static long FindPrevNumber(string input) => Sequence.Previous(ParseNumbers(input));
    private static IEnumerable<long> ParseNumbers(string input) => input.Split(' ').Select(long.Parse);
}

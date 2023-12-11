using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202309;

[Name("Mirage Maintenance")]
public class Aoc202309(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1() => 
        new(Part1(Input), "42abec426a1f1903197aaf0635b6a29a");

    protected override PuzzleResult RunPart2() => 
        new(Part2(Input), "652e203bd80c5889b310a0a8efdb2301");

    public static long Part1(string input) => 
        StringReader.ReadLines(input).Select(FindNextNumber).Sum();

    public static long Part2(string input) => 
        StringReader.ReadLines(input).Select(FindPrevNumber).Sum();

    public static long FindNextNumber(string input) => 
        Sequence.Next(ParseNumbers(input));

    public static long FindPrevNumber(string input) => 
        Sequence.Previous(ParseNumbers(input));

    private static IEnumerable<long> ParseNumbers(string input) => 
        input.Split(' ').Select(long.Parse);
}

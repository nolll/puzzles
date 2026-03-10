using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202103;

[Name("Binary Diagnostic")]
public class Aoc202103 : AocPuzzle
{
    [Puzzle("a1a6d0eb7bc34e96753cd342f3c1d6d2")]
    public PuzzleResult Part1(string input)
    {
        var diagnostics = new BinaryDiagnostics();
        var result = diagnostics.GetFuelConsumption(input);
            
        return new PuzzleResult(result);
    }

    [Puzzle("66f52493d3c80314725bfa6aa672f2af")]
    public PuzzleResult Part2(string input)
    {
        var diagnostics = new BinaryDiagnostics();
        var result = diagnostics.GetLifeSupportRating(input);

        return new PuzzleResult(result);
    }
}
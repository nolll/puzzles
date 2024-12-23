using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202103;

[Name("Binary Diagnostic")]
public class Aoc202103 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var diagnostics = new BinaryDiagnostics();
        var result = diagnostics.GetFuelConsumption(input);
            
        return new PuzzleResult(result, "a1a6d0eb7bc34e96753cd342f3c1d6d2");
    }

    public PuzzleResult RunPart2(string input)
    {
        var diagnostics = new BinaryDiagnostics();
        var result = diagnostics.GetLifeSupportRating(input);

        return new PuzzleResult(result, "66f52493d3c80314725bfa6aa672f2af");
    }
}
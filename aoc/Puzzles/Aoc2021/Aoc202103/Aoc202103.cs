using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2021.Aoc202103;

public class Aoc202103 : AocPuzzle
{
    public override string Name => "Binary Diagnostic";

    protected override PuzzleResult RunPart1()
    {
        var diagnostics = new BinaryDiagnostics();
        var result = diagnostics.GetFuelConsumption(InputFile);
            
        return new PuzzleResult(result, "a1a6d0eb7bc34e96753cd342f3c1d6d2");
    }

    protected override PuzzleResult RunPart2()
    {
        var diagnostics = new BinaryDiagnostics();
        var result = diagnostics.GetLifeSupportRating(InputFile);

        return new PuzzleResult(result, "66f52493d3c80314725bfa6aa672f2af");
    }
}
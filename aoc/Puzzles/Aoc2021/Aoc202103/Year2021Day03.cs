using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202103;

public class Year2021Day03 : AocPuzzle
{
    public override string Name => "Binary Diagnostic";

    protected override PuzzleResult RunPart1()
    {
        var diagnostics = new BinaryDiagnostics();
        var result = diagnostics.GetFuelConsumption(InputFile);
            
        return new PuzzleResult(result, 845186);
    }

    protected override PuzzleResult RunPart2()
    {
        var diagnostics = new BinaryDiagnostics();
        var result = diagnostics.GetLifeSupportRating(InputFile);

        return new PuzzleResult(result, 4636702);
    }
}
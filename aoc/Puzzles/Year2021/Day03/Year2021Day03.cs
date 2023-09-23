using Common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day03;

public class Year2021Day03 : AocPuzzle
{
    public override string Name => "Binary Diagnostic";

    protected override PuzzleResult RunPart1()
    {
        var diagnostics = new BinaryDiagnostics();
        var result = diagnostics.GetFuelConsumption(FileInput);
            
        return new PuzzleResult(result, 845186);
    }

    protected override PuzzleResult RunPart2()
    {
        var diagnostics = new BinaryDiagnostics();
        var result = diagnostics.GetLifeSupportRating(FileInput);

        return new PuzzleResult(result, 4636702);
    }
}
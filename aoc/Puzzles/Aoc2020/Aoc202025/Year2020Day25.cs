using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202025;

public class Year2020Day25 : AocPuzzle
{
    public override string Name => "Combo Breaker";

    protected override PuzzleResult RunPart1()
    {
        var finder = new EncryptionKeyFinder(InputFile);
        var key = finder.FindKey();

        return new PuzzleResult(key, 7269858);
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}
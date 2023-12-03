using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202025;

public class Aoc202025 : AocPuzzle
{
    public override string Name => "Combo Breaker";

    protected override PuzzleResult RunPart1()
    {
        var finder = new EncryptionKeyFinder(InputFile);
        var key = finder.FindKey();

        return new PuzzleResult(key, "340def679154dbcee66df7e80ce2dd0d");
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}
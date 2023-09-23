using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day21;

public class Year2021Day21 : AocPuzzle
{
    public override string Name => "Dirac Dice";

    protected override PuzzleResult RunPart1()
    {
        var game = new DiracDiceGame();
        var result = game.Play(8, 2);

        return new PuzzleResult(result.Result, 513936);
    }

    protected override PuzzleResult RunPart2()
    {
        var game = new RealDiracDiceGame();
        var result = game.Play(8, 2);

        return new PuzzleResult(result, 105619718613031);
    }
}
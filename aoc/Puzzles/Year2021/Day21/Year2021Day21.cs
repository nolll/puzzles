using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day21;

public class Year2021Day21 : AocPuzzle
{
    public override string Name => "Dirac Dice";

    public override PuzzleResult RunPart1()
    {
        var game = new DiracDiceGame();
        var result = game.Play(8, 2);

        return new PuzzleResult(result.Result, 513936);
    }

    public override PuzzleResult RunPart2()
    {
        var game = new RealDiracDiceGame();
        var result = game.Play(8, 2);

        return new PuzzleResult(result, 105619718613031);
    }
}
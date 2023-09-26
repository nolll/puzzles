using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202121;

public class Aoc202121 : AocPuzzle
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
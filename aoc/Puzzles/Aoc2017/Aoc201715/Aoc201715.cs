using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Aoc201715;

public class Aoc201715 : AocPuzzle
{
    public override string Name => "Dueling Generators";

    protected override PuzzleResult RunPart1()
    {
        var duel = GeneratorDuel.Parse(InputFile);
        duel.Run(40_000_000);
        return new PuzzleResult(duel.FinalCount, 626);
    }

    protected override PuzzleResult RunPart2()
    {
        var duel2 = GeneratorDuel.Parse(InputFile);
        duel2.Run2(5_000_000);
        return new PuzzleResult(duel2.FinalCount, 306);
    }
}
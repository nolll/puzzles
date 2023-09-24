using Common.Puzzles;

namespace Aoc.Puzzles.Year2017.Day18;

public class Year2017Day18 : AocPuzzle
{
    public override string Name => "Duet";

    protected override PuzzleResult RunPart1()
    {
        var single = new SingleRunner(InputFile);
        single.Run();
        return new PuzzleResult(single.RecoveredFrequency, 4601);
    }

    protected override PuzzleResult RunPart2()
    {
        var duet = new DuetRunner(InputFile);
        duet.Run();
        return new PuzzleResult(duet.Program1SendCount, 6858);
    }
}
using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2017.Day18;

public class Year2017Day18 : AocPuzzle
{
    public override string Name => "Duet";

    public override PuzzleResult RunPart1()
    {
        var single = new SingleRunner(FileInput);
        single.Run();
        return new PuzzleResult(single.RecoveredFrequency, 4601);
    }

    public override PuzzleResult RunPart2()
    {
        var duet = new DuetRunner(FileInput);
        duet.Run();
        return new PuzzleResult(duet.Program1SendCount, 6858);
    }
}
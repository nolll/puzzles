using Core.Platform;

namespace Core.Puzzles.Year2017.Day18;

public class Year2017Day18 : Puzzle
{
    public override string Title => "Duet";

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
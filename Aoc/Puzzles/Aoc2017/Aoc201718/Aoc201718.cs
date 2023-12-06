using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201718;

public class Aoc201718 : AocPuzzle
{
    public override string Name => "Duet";

    protected override PuzzleResult RunPart1()
    {
        var single = new SingleRunner(InputFile);
        single.Run();
        return new PuzzleResult(single.RecoveredFrequency, "83f5054894620fa4e35d5a042e71f9a0");
    }

    protected override PuzzleResult RunPart2()
    {
        var duet = new DuetRunner(InputFile);
        duet.Run();
        return new PuzzleResult(duet.Program1SendCount, "5bfcd9b6e8755474ab31f818b763418e");
    }
}
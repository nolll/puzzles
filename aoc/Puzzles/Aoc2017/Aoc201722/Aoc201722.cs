using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2017.Aoc201722;

public class Aoc201722 : AocPuzzle
{
    public override string Name => "Sporifica Virus";

    protected override PuzzleResult RunPart1()
    {
        var infection1 = new VirusInfection(InputFile);
        var infectionCount1 = infection1.RunPart1(10_000);
        return new PuzzleResult(infectionCount1, "ae293a43b47d6820d75321581ad234d0");
    }

    protected override PuzzleResult RunPart2()
    {
        var infection2 = new VirusInfection(InputFile);
        var infectionCount2 = infection2.RunPart2(10_000_000);
        return new PuzzleResult(infectionCount2, "890e30fb9efa1c72b53fa911a105caa2");
    }
}
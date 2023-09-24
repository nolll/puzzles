using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Day22;

public class Year2017Day22 : AocPuzzle
{
    public override string Name => "Sporifica Virus";

    protected override PuzzleResult RunPart1()
    {
        var infection1 = new VirusInfection(InputFile);
        var infectionCount1 = infection1.RunPart1(10_000);
        return new PuzzleResult(infectionCount1, 5538);
    }

    protected override PuzzleResult RunPart2()
    {
        var infection2 = new VirusInfection(InputFile);
        var infectionCount2 = infection2.RunPart2(10_000_000);
        return new PuzzleResult(infectionCount2, 2_511_090);
    }
}
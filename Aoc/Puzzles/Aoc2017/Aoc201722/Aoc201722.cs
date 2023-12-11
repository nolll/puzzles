using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201722;

[Name("Sporifica Virus")]
public class Aoc201722(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var infection1 = new VirusInfection(Input);
        var infectionCount1 = infection1.RunPart1(10_000);
        return new PuzzleResult(infectionCount1, "ae293a43b47d6820d75321581ad234d0");
    }

    protected override PuzzleResult RunPart2()
    {
        var infection2 = new VirusInfection(Input);
        var infectionCount2 = infection2.RunPart2(10_000_000);
        return new PuzzleResult(infectionCount2, "890e30fb9efa1c72b53fa911a105caa2");
    }
}
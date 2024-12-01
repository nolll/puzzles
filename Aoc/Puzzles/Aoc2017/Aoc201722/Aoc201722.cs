using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201722;

[Name("Sporifica Virus")]
public class Aoc201722 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var infection1 = new VirusInfection(input);
        var infectionCount1 = infection1.RunPart1(10_000);
        return new PuzzleResult(infectionCount1, "ae293a43b47d6820d75321581ad234d0");
    }

    public PuzzleResult RunPart2(string input)
    {
        var infection2 = new VirusInfection(input);
        var infectionCount2 = infection2.RunPart2(10_000_000);
        return new PuzzleResult(infectionCount2, "890e30fb9efa1c72b53fa911a105caa2");
    }
}
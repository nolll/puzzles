using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201722;

[Name("Sporifica Virus")]
public class Aoc201722 : AocPuzzle
{
    [Puzzle("ae293a43b47d6820d75321581ad234d0")]
    public int Part1(string input) => new VirusInfection(input).RunPart1(10_000);

    [Puzzle("890e30fb9efa1c72b53fa911a105caa2")]
    public int Part2(string input) => new VirusInfection(input).RunPart2(10_000_000);
}
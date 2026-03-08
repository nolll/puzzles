using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201505;

[Name("Doesn't He Have Intern-Elves For This?")]
public class Aoc201505: AocPuzzle
{
    [Puzzle("9acaaf3fc5bc7b60d024ccf5dee1c098")]
    public int Part1(string input) => NaughtyOrNiceEvaluator.GetNiceCount1(input);

    [Puzzle("5363390b461681375e68f3cea9b968df")]
    public int Part2(string input) => NaughtyOrNiceEvaluator.GetNiceCount2(input);
}
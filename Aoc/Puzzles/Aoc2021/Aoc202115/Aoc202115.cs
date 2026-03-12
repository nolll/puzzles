using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202115;

[Name("Chiton")]
public class Aoc202115 : AocPuzzle
{
    [Puzzle("044f1b14974612cad17255d7683d0892")]
    public int Part1(string input) => new ChitonRisk().FindRiskLevelForSmallCave(input);

    [Puzzle("99cda5f07b0381340587915a1e9f5cb2")]
    public int Part2(string input) => new ChitonRisk().FindRiskLevelForLargeCave(input);
}
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201903;

[Name("Crossed Wires")]
public class Aoc201903 : AocPuzzle
{
    [Puzzle("3dbd15d37a682cfa1ca55525a248c184")]
    public int Part1(string input)
    {
        var (a, b) = input.Split(LineBreaks.Single);
        return new IntersectionFinder(a, b).ClosestIntersection.Distance;
    }

    [Puzzle("51670676a41763c6093416dd009a8ba6")]
    public int Part2(string input)
    {
        var (a, b) = input.Split(LineBreaks.Single);
        return new IntersectionFinder(a, b).FewestSteps.Steps;
    }
}
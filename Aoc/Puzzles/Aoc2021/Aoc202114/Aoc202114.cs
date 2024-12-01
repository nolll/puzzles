using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202114;

[Name("Extended Polymerization")]
public class Aoc202114 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(input, 10);

        return new PuzzleResult(result, "1efc37e1defc93f45f72522371cce05c");
    }

    public PuzzleResult RunPart2(string input)
    {
        var polymerization = new Polymerization();
        var result = polymerization.Run(input, 40);

        return new PuzzleResult(result, "d36de0cab46393825975a1adaea40dc4");
    }
}
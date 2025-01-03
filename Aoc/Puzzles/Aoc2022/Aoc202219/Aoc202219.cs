using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202219;

[Name("Not Enough Minerals")]
public class Aoc202219 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var factory = new RobotFactory();
        var result = factory.Part1(input);

        return new PuzzleResult(result, "11353deb56afd92426a160a11f5506b0");
    }

    public PuzzleResult RunPart2(string input)
    {
        var factory = new RobotFactory();
        var result = factory.Part2(input);

        return new PuzzleResult(result, "a5034749df5937c49bba3b06acc7119c");
    }
}
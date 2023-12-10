using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202219;

[Name("Not Enough Minerals")]
public class Aoc202219 : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var factory = new RobotFactory();
        var result = factory.Part1(InputFile);

        return new PuzzleResult(result, "11353deb56afd92426a160a11f5506b0");
    }

    protected override PuzzleResult RunPart2()
    {
        var factory = new RobotFactory();
        var result = factory.Part2(InputFile);

        return new PuzzleResult(result, "a5034749df5937c49bba3b06acc7119c");
    }
}
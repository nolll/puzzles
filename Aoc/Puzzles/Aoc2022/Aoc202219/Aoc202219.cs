using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202219;

[Name("Not Enough Minerals")]
public class Aoc202219 : AocPuzzle
{
    [Puzzle("11353deb56afd92426a160a11f5506b0")]
    public PuzzleResult Part1(string input)
    {
        var factory = new RobotFactory();
        var result = factory.Part1(input);

        return new PuzzleResult(result);
    }

    [Puzzle("a5034749df5937c49bba3b06acc7119c")]
    public PuzzleResult Part2(string input)
    {
        var factory = new RobotFactory();
        var result = factory.Part2(input);

        return new PuzzleResult(result);
    }
}
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202219;

[Name("Not Enough Minerals")]
public class Aoc202219 : AocPuzzle
{
    [Puzzle("11353deb56afd92426a160a11f5506b0")]
    public int Part1(string input) => new RobotFactory().Part1(input);

    [Puzzle("a5034749df5937c49bba3b06acc7119c")]
    public int Part2(string input) => new RobotFactory().Part2(input);
}
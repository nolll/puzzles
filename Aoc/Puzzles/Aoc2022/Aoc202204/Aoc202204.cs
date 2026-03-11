using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202204;

[Name("Camp Cleanup")]
public class Aoc202204 : AocPuzzle
{
    [Puzzle("9569cfbf59abc27202b8777006153703")]
    public int Part1(string input) => new Cleaning().Part1(input);

    [Puzzle("1cf622579ace09c8f182b5640835416f")]
    public int Part2(string input) => new Cleaning().Part2(input);
}
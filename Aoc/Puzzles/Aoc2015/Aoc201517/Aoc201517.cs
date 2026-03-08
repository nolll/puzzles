using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201517;

[Name("No Such Thing as Too Much")]
public class Aoc201517 : AocPuzzle
{
    [Puzzle("5c9cb3225ec72026a92a9d18b0257800")]
    public int Part1(string input) => new EggnogContainers(input).GetCombinations(150).Count;

    [Puzzle("b5099aa249856738b5000cb46145f473")]
    public int Part2(string input) => new EggnogContainers(input).GetCombinationsWithLeastContainers(150).Count;
}
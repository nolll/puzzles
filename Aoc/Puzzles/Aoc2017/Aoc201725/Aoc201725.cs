using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201725;

[Name("The Halting Problem")]
public class Aoc201725 : AocPuzzle
{
    [Puzzle("a18cb67e5cdfb9d5e9a4afd12de0d627")]
    public int Part1(string input) => new TuringMachine(input).Run();
}
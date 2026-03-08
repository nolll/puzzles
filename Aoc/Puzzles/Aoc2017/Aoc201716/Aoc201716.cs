using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201716;

[Name("Permutation Promenade")]
public class Aoc201716 : AocPuzzle
{
    [Puzzle("54e5dfe8c4867e76716033345f70c9ad")]
    public string Part1(string input)
    {
        var dancingPrograms = new DancingPrograms();
        dancingPrograms.Dance(input, 1);
        return dancingPrograms.Programs;
    }

    [Puzzle("023321046c58453f7009348c8a83a89c")]
    public string Part2(string input)
    {
        var dancingPrograms = new DancingPrograms();
        dancingPrograms.Dance(input, 1_000_000_000);
        return dancingPrograms.Programs;
    }
}
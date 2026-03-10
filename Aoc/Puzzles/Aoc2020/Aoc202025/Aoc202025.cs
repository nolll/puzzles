using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202025;

[Name("Combo Breaker")]
public class Aoc202025 : AocPuzzle
{
    [Puzzle("340def679154dbcee66df7e80ce2dd0d")]
    public PuzzleResult Part1(string input)
    {
        var finder = new EncryptionKeyFinder(input);
        var key = finder.FindKey();

        return new PuzzleResult(key);
    }
}
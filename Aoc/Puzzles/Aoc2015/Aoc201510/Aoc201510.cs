using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201510;

[Name("Elves Look, Elves Say")]
public class Aoc201510() : AocPuzzle("1113222113")
{
    protected override PuzzleResult RunPart1()
    {
        var game = new LookAndSayGame(Input, 40);
        return new PuzzleResult(game.Result.Length, "1c32a9d4af561a5e8468442397ce06c0");
    }

    protected override PuzzleResult RunPart2()
    {
        var game2 = new LookAndSayGame(Input, 50);
        return new PuzzleResult(game2.Result.Length, "f96f3f93bd5cbf8f3cf1bcf814ba4707");
    }
}
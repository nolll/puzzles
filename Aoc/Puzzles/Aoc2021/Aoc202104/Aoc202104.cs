using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202104;

public class Aoc202104 : AocPuzzle
{
    public override string Name => "Giant Squid";

    protected override PuzzleResult RunPart1()
    {
        var diagnostics = new BingoGame(InputFile);
        var result = diagnostics.Play(false);

        return new PuzzleResult(result, "95287604b1b5cd043b3268068d4c34ef");
    }

    protected override PuzzleResult RunPart2()
    {
        var diagnostics = new BingoGame(InputFile);
        var result = diagnostics.Play(true);

        return new PuzzleResult(result, "d3b6f7e7618d28f0aac8b2a2c99f5b2e");
    }
}
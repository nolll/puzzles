using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

[Name("Pyroclastic Flow")]
public class Aoc202217 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var tetris = new Tetris();
        var result = tetris.Run(input, 2022);

        return new PuzzleResult(result, "cdc90a19ac724ffd4fa126a641706d13");
    }

    public PuzzleResult RunPart2(string input)
    {
        var tetris = new Tetris();
        var result = tetris.Run(input, 1_000_000_000_000);

        return new PuzzleResult(result, "3a90eb3ba5f3fc471fa832e199a1b7f9");
    }
}   
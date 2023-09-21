using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day04;

public class Year2015Day04 : AocPuzzle
{
    private int _index;

    public override string Title => "The Ideal Stocking Stuffer";

    public override PuzzleResult RunPart1()
    {
        var coin = AdventCoinMiner.Mine(Input, 5);
        _index = coin;
        return new PuzzleResult(coin, 346_386);
    }

    public override PuzzleResult RunPart2()
    {
        var coin = AdventCoinMiner.Mine(Input, 6, _index);
        return new PuzzleResult(coin, 9_958_218);
    }

    private const string Input = "iwrupvqb";
}
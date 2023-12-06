using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201504;

public class Aoc201504 : AocPuzzle
{
    private int _index;

    public override string Name => "The Ideal Stocking Stuffer";

    protected override PuzzleResult RunPart1()
    {
        var coin = AdventCoinMiner.Mine(Input, 5);
        _index = coin;
        return new PuzzleResult(coin, "e89372908b5202e6ce4d69a8b3538295");
    }

    protected override PuzzleResult RunPart2()
    {
        var coin = AdventCoinMiner.Mine(Input, 6, _index);
        return new PuzzleResult(coin, "9eb348bda7d61e7026099765b89a55fa");
    }

    private const string Input = "iwrupvqb";
}
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202015;

public class Aoc202015 : AocPuzzle
{
    public override string Name => "Rambunctious Recitation";

    protected override PuzzleResult RunPart1()
    {
        var system = new MemoryGame(Input);
        var result = system.Play(2020);
        return new PuzzleResult(result, "9b1872aba49cfd16a3cc25436caa89e4");
    }

    protected override PuzzleResult RunPart2()
    {
        var system = new MemoryGame(Input);
        var result = system.Play(30000000);
        return new PuzzleResult(result, "7bcf2e0ed295f1de70b3d5368e465107");
    }

    private const string Input = "12,1,16,3,11,0";
}
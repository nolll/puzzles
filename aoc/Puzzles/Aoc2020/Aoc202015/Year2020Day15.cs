using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202015;

public class Year2020Day15 : AocPuzzle
{
    public override string Name => "Rambunctious Recitation";

    protected override PuzzleResult RunPart1()
    {
        var system = new MemoryGame(Input);
        var result = system.Play(2020);
        return new PuzzleResult(result, 1696);
    }

    protected override PuzzleResult RunPart2()
    {
        var system = new MemoryGame(Input);
        var result = system.Play(30000000);
        return new PuzzleResult(result, 37_385);
    }

    private const string Input = "12,1,16,3,11,0";
}
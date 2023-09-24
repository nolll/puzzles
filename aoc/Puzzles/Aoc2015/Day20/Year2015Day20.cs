using Common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day20;

public class Year2015Day20 : AocPuzzle
{
    public override string Name => "Infinite Elves and Infinite Houses";

    protected override PuzzleResult RunPart1()
    {
        var presentDelivery = new PresentDelivery();
        var house = presentDelivery.Deliver1(Input, true);
        return new PuzzleResult(house, 786_240);
    }

    protected override PuzzleResult RunPart2()
    {
        var presentDelivery = new PresentDelivery();
        var house = presentDelivery.Deliver2(Input);
        return new PuzzleResult(house, 831_600);
    }

    private const int Input = 34_000_000;
}
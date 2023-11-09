using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201520;

public class Aoc201520 : AocPuzzle
{
    public override string Name => "Infinite Elves and Infinite Houses";

    protected override PuzzleResult RunPart1()
    {
        var presentDelivery = new PresentDelivery();
        var house = presentDelivery.Deliver1(Input, true);
        return new PuzzleResult(house, "0c8e60136d2393905b0cf33e2062864e");
    }

    protected override PuzzleResult RunPart2()
    {
        var presentDelivery = new PresentDelivery();
        var house = presentDelivery.Deliver2(Input);
        return new PuzzleResult(house, "ef369a6f63a7879f19640219124debe7");
    }

    private const int Input = 34_000_000;
}
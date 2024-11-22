using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201520;

[Name("Infinite Elves and Infinite Houses")]
public class Aoc201520(string input) : AocPuzzle
{
    private int IntInput => int.Parse(input);

    protected override PuzzleResult RunPart1()
    {
        var presentDelivery = new PresentDelivery();
        var house = presentDelivery.Deliver1(IntInput, true);
        return new PuzzleResult(house, "0c8e60136d2393905b0cf33e2062864e");
    }

    protected override PuzzleResult RunPart2()
    {
        var presentDelivery = new PresentDelivery();
        var house = presentDelivery.Deliver2(IntInput);
        return new PuzzleResult(house, "ef369a6f63a7879f19640219124debe7");
    }
}
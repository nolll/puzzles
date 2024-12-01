using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201520;

[Name("Infinite Elves and Infinite Houses")]
public class Aoc201520 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var presentDelivery = new PresentDelivery();
        var house = presentDelivery.Deliver1(int.Parse(input), true);
        return new PuzzleResult(house, "0c8e60136d2393905b0cf33e2062864e");
    }

    public PuzzleResult RunPart2(string input)
    {
        var presentDelivery = new PresentDelivery();
        var house = presentDelivery.Deliver2(int.Parse(input));
        return new PuzzleResult(house, "ef369a6f63a7879f19640219124debe7");
    }
}
namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202007;

public class SubBag
{
    public Bag Bag { get; }
    public int Quantity { get; }

    public SubBag(Bag bag, int quantity)
    {
        Bag = bag;
        Quantity = quantity;
    }
}
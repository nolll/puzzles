namespace Aoc.Puzzles.Year2019.Day14;

public class ChemicalQuantity
{
    public string Name { get; }
    public long Quantity { get; }

    public ChemicalQuantity(string name, long quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}
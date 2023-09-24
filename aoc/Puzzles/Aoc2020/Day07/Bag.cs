using System.Collections.Generic;

namespace Aoc.Puzzles.Year2020.Day07;

public class Bag
{
    public string Name { get; }
    public List<SubBag> SubBags { get; }

    public Bag(string name)
    {
        Name = name;
        SubBags = new List<SubBag>();
    }

    public void AddSubBag(Bag bag, int quantity)
    {
        SubBags.Add(new SubBag(bag, quantity));
    }
}
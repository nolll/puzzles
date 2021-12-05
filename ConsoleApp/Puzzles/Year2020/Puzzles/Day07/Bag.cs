using System.Collections.Generic;

namespace ConsoleApp.Puzzles.Year2020.Puzzles.Day07
{
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
}
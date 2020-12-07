using System.Collections.Generic;

namespace Core.LuggageRules
{
    public class Bag
    {
        public string Name { get; }
        public List<SubBag> SubBags { get; }
        public List<Bag> ParentBags { get; }

        public Bag(string name)
        {
            Name = name;
            SubBags = new List<SubBag>();
            ParentBags = new List<Bag>();
        }

        public void AddSubBag(Bag bag, int quantity)
        {
            SubBags.Add(new SubBag(bag, quantity));
        }

        public void AddParentBag(Bag bag)
        {
            ParentBags.Add(bag);
        }
    }
}
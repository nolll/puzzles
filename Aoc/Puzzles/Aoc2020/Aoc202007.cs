using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Handy Haversacks")]
public class Aoc202007 : AocPuzzle
{
    [Puzzle("e58b666bd08fdb2db4284193545ca076")]
    public int Part1(string input) => new LuggageProcessor(input).NumberOfBagsThatCanContainGoldBags();

    [Puzzle("0362b078252328a96bca4cbfb7bcf250")]
    public int Part2(string input) => new LuggageProcessor(input).NumberOfBagsThatAGoldBagContains();

    public class LuggageProcessor
    {
        private readonly Dictionary<string, Bag> _bags;

        public LuggageProcessor(string input)
        {
            _bags = new Dictionary<string, Bag>();
            ParseBags(input);
        }

        private void ParseBags(string input)
        {
            var rows = input.Split(LineBreaks.Single);
            foreach (var row in rows)
            {
                ParseBag(row);
            }
        }

        private void ParseBag(string row)
        {
            var parts = row.Split("contain").Select(o => o.Trim()).ToList();
            var bagName = parts[0].Replace("bags", "").Trim();
            var bag = GetOrAdd(bagName);
            var allSubBagsString = parts[1].Replace(".", "");
            if (allSubBagsString == "no other bags")
                return;

            var subBagsStrings = allSubBagsString.Split(",");
            foreach (var subBagString in subBagsStrings)
            {
                var subBagParts = subBagString.Trim().Split(" ").SkipLast(1).ToList();
                var quantity = int.Parse(subBagParts.First());
                var name = string.Join(" ", subBagParts.Skip(1));
                var subBag = GetOrAdd(name);
                bag.AddSubBag(subBag, quantity);
            }
        }

        private Bag GetOrAdd(string bagName)
        {
            if (_bags.TryGetValue(bagName, out var bag))
                return bag;

            bag = new Bag(bagName);
            _bags.Add(bagName, bag);
            return bag;
        }

        public int NumberOfBagsThatCanContainGoldBags()
        {
            var count = 0;
            foreach (var bag in _bags.Values)
            {
                count += CanContainGoldenBag(bag)
                    ? 1
                    : 0;
            }

            return count;
        }

        private static bool CanContainGoldenBag(Bag bag)
        {
            foreach (var subBag in bag.SubBags)
            {
                if (subBag.Bag.Name == "shiny gold")
                    return true;

                if (CanContainGoldenBag(subBag.Bag))
                    return true;
            }

            return false;
        }

        public int NumberOfBagsThatAGoldBagContains() => GetSubBagCount(_bags["shiny gold"]);

        private int GetSubBagCount(Bag bag)
        {
            var count = 0;
            foreach (var subBag in bag.SubBags)
            {
                count += subBag.Quantity + subBag.Quantity * GetSubBagCount(subBag.Bag);
            }

            return count;
        }
    }
    
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
}
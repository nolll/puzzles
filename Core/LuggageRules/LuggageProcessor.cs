using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.LuggageRules
{
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
            var rows = PuzzleInputReader.ReadLines(input);
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
            if (allSubBagsString != "no other bags")
            {
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

        private bool CanContainGoldenBag(Bag bag)
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

        public int NumberOfBagsThatAGoldBagContains()
        {
            var goldBag = _bags["shiny gold"];
            return GetSubBagCount(goldBag);
        }

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
}
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Handy Haversacks")]
public class Aoc202007 : AocPuzzle
{
    [Puzzle("e58b666bd08fdb2db4284193545ca076")]
    public int Part1(string input) => ParseBags(input).Values.Sum(bag => CanContainGoldenBag(bag) ? 1 : 0);

    [Puzzle("0362b078252328a96bca4cbfb7bcf250")]
    public int Part2(string input) => GetSubBagCount(ParseBags(input)["shiny gold"]);

    private static Dictionary<string, Bag> ParseBags(string input)
    {
        var bags = new Dictionary<string, Bag>();
        var rows = input.Split(LineBreaks.Single);
        foreach (var row in rows)
            ParseBag(bags, row);

        return bags;
    }

    private static void ParseBag(Dictionary<string, Bag> bags, string row)
    {
        var parts = row.Split("contain").Select(o => o.Trim()).ToList();
        var bagName = parts[0].Replace("bags", "").Trim();
        var bag = GetOrAdd(bags, bagName);
        var allSubBagsString = parts[1].Replace(".", "");
        if (allSubBagsString == "no other bags")
            return;

        var subBagsStrings = allSubBagsString.Split(",");
        foreach (var subBagString in subBagsStrings)
        {
            var subBagParts = subBagString.Trim().Split(" ").SkipLast(1).ToList();
            var quantity = int.Parse(subBagParts.First());
            var name = string.Join(" ", subBagParts.Skip(1));
            var subBag = GetOrAdd(bags, name);
            bag.AddSubBag(subBag, quantity);
        }
    }

    private static Bag GetOrAdd(Dictionary<string, Bag> bags, string bagName)
    {
        if (bags.TryGetValue(bagName, out var bag))
            return bag;

        bag = new Bag(bagName);
        bags.Add(bagName, bag);
        return bag;
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

    private static int GetSubBagCount(Bag bag) => bag.SubBags.Sum(subBag => subBag.Quantity + subBag.Quantity * GetSubBagCount(subBag.Bag));

    public record Bag(string Name)
    {
        public List<SubBag> SubBags { get; } = new();
        public void AddSubBag(Bag bag, int quantity) => SubBags.Add(new SubBag(bag, quantity));
    }

    public record SubBag(Bag Bag, int Quantity);
}
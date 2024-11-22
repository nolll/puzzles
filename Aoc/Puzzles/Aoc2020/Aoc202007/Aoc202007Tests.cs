using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202007;

public class Aoc202007Tests
{
    [Test]
    public void NumberOfBagsThatCanCarryGoldBags()
    {
        const string input = """
                             light red bags contain 1 bright white bag, 2 muted yellow bags.
                             dark orange bags contain 3 bright white bags, 4 muted yellow bags.
                             bright white bags contain 1 shiny gold bag.
                             muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
                             shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
                             dark olive bags contain 3 faded blue bags, 4 dotted black bags.
                             vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
                             faded blue bags contain no other bags.
                             dotted black bags contain no other bags.
                             """;

        var processor = new LuggageProcessor(input.Trim());
        var count = processor.NumberOfBagsThatCanContainGoldBags();

        count.Should().Be(4);
    }

    [Test]
    public void NumberOfBagsThatAGoldBagsContains()
    {
        const string input = """
                             light red bags contain 1 bright white bag, 2 muted yellow bags.
                             dark orange bags contain 3 bright white bags, 4 muted yellow bags.
                             bright white bags contain 1 shiny gold bag.
                             muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
                             shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
                             dark olive bags contain 3 faded blue bags, 4 dotted black bags.
                             vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
                             faded blue bags contain no other bags.
                             dotted black bags contain no other bags.
                             """;

        var processor = new LuggageProcessor(input.Trim());
        var count = processor.NumberOfBagsThatAGoldBagContains();

        count.Should().Be(32);
    }
}
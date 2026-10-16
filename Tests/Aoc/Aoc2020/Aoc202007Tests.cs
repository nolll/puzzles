using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202007Tests : PuzzleTest<Aoc202007>
{
    private const string Input = """
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

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(4);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(32);
}
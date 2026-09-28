using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202203Tests
{
    [Fact]
    public void Part1()
    {
        var result = Aoc202203.Rucksacks.GetPriority1(Input);

        result.Should().Be(157);
    }

    [Fact]
    public void Part2()
    {
        var result = Aoc202203.Rucksacks.GetPriority2(Input);

        result.Should().Be(70);
    }

    private const string Input = """
                                 vJrwpWtwJgWrhcsFMMfFFhFp
                                 jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
                                 PmmdzqPrVvPwwTWBwg
                                 wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
                                 ttgJtRGJQctTZtZT
                                 CrZsJsPPZsGzwwsLwLmpwMDw
                                 """;
}
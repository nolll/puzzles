using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2022.Aoc202203;

public class Aoc202203Tests
{
    [Test]
    public void Part1()
    {
        var result = Rucksacks.GetPriority1(Input);

        result.Should().Be(157);
    }

    [Test]
    public void Part2()
    {
        var result = Rucksacks.GetPriority2(Input);

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
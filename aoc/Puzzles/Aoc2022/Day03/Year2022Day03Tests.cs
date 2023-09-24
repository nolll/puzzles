using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2022.Day03;

public class Year2022Day03Tests
{
    [Test]
    public void Part1()
    {
        var result = Rucksacks.GetPriority1(Input);

        Assert.That(result, Is.EqualTo(157));
    }

    [Test]
    public void Part2()
    {
        var result = Rucksacks.GetPriority2(Input);

        Assert.That(result, Is.EqualTo(70));
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
using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day03;

public class Year2022Day03Tests
{
    [Test]
    public void Part1()
    {
        var rucksacks = new Rucksacks();
        var result = rucksacks.GetPriority1(Input);

        Assert.That(result, Is.EqualTo(157));
    }

    [Test]
    public void Part2()
    {
        var rucksacks = new Rucksacks();
        var result = rucksacks.GetPriority2(Input);

        Assert.That(result, Is.EqualTo(70));
    }

    private const string Input = @"
vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";
}
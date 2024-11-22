using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201516;

public class Aoc201516Tests
{
    [Test]
    public void SelectsCorrectAuntSue()
    {
        const string input = """
                             Sue 1: pomeranians: 3, perfumes: 6, vizslas: 0
                             Sue 2: vizslas: 0, perfumes: 1, trees: 3
                             Sue 3: vizslas: 7, pomeranians: 1, akitas: 10
                             """;

        var sueSelector = new SueSelector(input.Trim());

        sueSelector.SueNumberPart1.Should().Be(2);
    }
}
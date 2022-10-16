using NUnit.Framework;

namespace Core.Puzzles.Year2015.Day16;

public class Year2015Day16Tests
{
    [Test]
    public void SelectsCorrectAuntSue()
    {
        const string input = @"
Sue 1: pomeranians: 3, perfumes: 6, vizslas: 0
Sue 2: vizslas: 0, perfumes: 1, trees: 3
Sue 3: vizslas: 7, pomeranians: 1, akitas: 10";

        var sueSelector = new SueSelector(input.Trim());

        Assert.That(sueSelector.SueNumberPart1, Is.EqualTo(2));
    }
}
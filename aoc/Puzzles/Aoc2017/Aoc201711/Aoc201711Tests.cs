using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2017.Aoc201711;

public class Aoc201711Tests
{
    [TestCase("ne,ne,ne", 3)]
    [TestCase("ne,ne,sw,sw", 0)]
    [TestCase("ne,ne,s,s", 2)]
    [TestCase("se,sw,se,sw,sw", 3)]
    public void DistanceIsCorrect(string input, int expected)
    {
        var navigator = new HexGridNavigator(input);

        Assert.That(navigator.EndDistance, Is.EqualTo(expected));
    }
}
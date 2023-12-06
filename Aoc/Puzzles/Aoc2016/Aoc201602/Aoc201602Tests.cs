using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201602;

public class Aoc201602Tests
{
    [Test]
    public void FindsSquareKeycode()
    {
        const string input = """
ULL
RRDDD
LURDL
UUUUD
""";

        var finder = new SquareKeyCodeFinder();
        var code = finder.Find(input.Trim());

        code.Should().Be("1985");
    }

    [Test]
    public void FindsDiamondKeycode()
    {
        const string input = """
ULL
RRDDD
LURDL
UUUUD
""";

        var finder = new DiamondKeyCodeFinder();
        var code = finder.Find(input.Trim());

        code.Should().Be("5DB3");
    }
}
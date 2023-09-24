using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Aoc201508;

public class Aoc201508Tests
{
    [Test]
    public void CodeToMemoryDifference()
    {
        const string input = """
""
"abc"
"aaa\"aaa"
"\x27"
""";

        var digitalList = new DigitalList(input.Trim());

        Assert.That(digitalList.CodeMinusMemoryDiff, Is.EqualTo(12));
    }

    [Test]
    public void EncodedToCodeDifference()
    {
        const string input = """
""
"abc"
"aaa\"aaa"
"\x27"
""";

        var digitalList = new DigitalList(input.Trim());

        Assert.That(digitalList.EncodedMinusCodeDiff, Is.EqualTo(19));
    }
}
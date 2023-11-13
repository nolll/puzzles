using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.euler.Puzzles.Euler042;

public class Euler042Tests
{
    [Test]
    public void GetWordValue()
    {
        var result = Euler042.GetWordValue("SKY");

        result.Should().Be(55);
    }

    [Test]
    public void GetTriangularNumbers()
    {
        var result = Euler042.GetTriangularNumbers(10).ToArray();

        result[0].Should().Be(1);
        result[1].Should().Be(3);
        result[2].Should().Be(6);
        result[3].Should().Be(10);
        result[4].Should().Be(15);
        result[5].Should().Be(21);
        result[6].Should().Be(28);
        result[7].Should().Be(36);
        result[8].Should().Be(45);
        result[9].Should().Be(55);
    }
}
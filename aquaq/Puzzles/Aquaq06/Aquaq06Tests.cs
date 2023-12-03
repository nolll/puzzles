using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aquaq.Puzzles.Aquaq06;

public class Aquaq06Tests
{
    [Test]
    public void CountOccurrencesOfOne()
    {
        var result = Aquaq06.FindOneCount(3);

        result.Should().Be(9);
    }
}
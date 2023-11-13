using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aquaq.Puzzles.Aquaq02;

public class Aquaq02Tests
{
    [Test]
    public void UniqueNumbers()
    {
        var input = new[]
        {
            1, 4, 3, 2, 4, 7, 2, 6, 3, 6
        };

        var result = Aquaq02.GetUniqueNumbers(input).ToArray();

        result.Count().Should().Be(5);
        result[0].Should().Be(1);
        result[1].Should().Be(4);
        result[2].Should().Be(7);
        result[3].Should().Be(2);
        result[4].Should().Be(6);
    }
}
using FluentAssertions;

namespace Pzl.Aquaq.Puzzles.Aquaq06;

public class Aquaq06Tests
{
    [Fact]
    public void CountOccurrencesOfOne()
    {
        var result = Aquaq06.FindOneCount(3);

        result.Should().Be(9);
    }
}
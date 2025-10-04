using FluentAssertions;

namespace Pzl.Aquaq.Puzzles.Aquaq31;

public class Aquaq31Tests
{
    [Fact]
    public void Rotate()
    {
        var result = Aquaq31.Rotate("U'LBRU");

        result.Should().Be(960);
    }
}
using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq31;

public class Aquaq31Tests
{
    [Test]
    public void Rotate()
    {
        var result = Aquaq31.Rotate("U'LBRU");

        result.Should().Be(960);
    }
}
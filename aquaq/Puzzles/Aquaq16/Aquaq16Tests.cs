using FluentAssertions;
using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq16;

public class Aquaq16Tests
{
    [Test]
    public void KerningSpaces()
    {
        var result = new Aquaq16().Run("LTA");

        result.Should().Be(53);
    }
}
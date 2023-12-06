using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler042;

public class Euler042Tests
{
    [Test]
    public void GetWordValue()
    {
        var result = Euler042.GetWordValue("SKY");

        result.Should().Be(55);
    }
}
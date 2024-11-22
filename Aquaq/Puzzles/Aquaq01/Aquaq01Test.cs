using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq01;

public class Aquaq01Test
{
    [Test]
    public void HexString()
    {
        var result = Aquaq01.GetHexString("kdb4life");

        result.Should().Be("0d40fe");
    }
}
using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq16;

public class Aquaq16Tests
{
    [Test]
    public void KerningSpaces()
    {
        const string input = "LTA";

        var result = new Aquaq16(input, "").Run(input);

        result.Should().Be(53);
    }
}
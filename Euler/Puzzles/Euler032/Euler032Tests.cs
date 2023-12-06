using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler032;

public class Euler032Tests
{
    [Test]
    public void IsPandigital()
    {
        var puzzle = new Euler032();
        var result = Euler032.IsPandigital(39, 186);

        result.Should().BeTrue();
    }

    [Test]
    public void IsNotPandigital()
    {
        var puzzle = new Euler032();
        var result = Euler032.IsPandigital(1, 2);

        result.Should().BeFalse();
    }
}
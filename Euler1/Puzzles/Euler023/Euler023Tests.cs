using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Euler.Puzzles.Euler023;

public class Euler023Tests
{
    [Test]
    public void Test()
    {
        var result = Euler023.FindAbundantNumbers(13);

        result.Count().Should().Be(1);
    }
}
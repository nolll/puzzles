using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.euler.Puzzles.Euler013;

public class Euler013Tests
{
    [Test]
    public void Test()
    {
        const string numbers = @"
10000000000000000000000000000000000000000000000000
20000000000000000000000000000000000000000000000000
30000000000000000000000000000000000000000000000000";

        var puzzle = new Euler013();
        var result = puzzle.Run(numbers);

        result.Should().Be("6000000000");
    }
}
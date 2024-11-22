using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler013;

public class Euler013Tests
{
    [Test]
    public void Test()
    {
        const string numbers = """
                               10000000000000000000000000000000000000000000000000
                               20000000000000000000000000000000000000000000000000
                               30000000000000000000000000000000000000000000000000
                               """;

        var puzzle = new Euler013(numbers);
        var result = puzzle.Run(numbers);

        result.Should().Be("6000000000");
    }
}
using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler011;

public class Euler011Tests
{
    [Test]
    public void Test()
    {
        const string grid = """
                            01 01 01 01 01
                            01 02 02 02 01
                            01 02 02 02 01
                            01 02 02 03 01
                            01 01 01 01 04
                            """;

        var puzzle = new Euler011();
        var result = puzzle.RunInternal(grid);

        result.Should().Be(48);
    }
}
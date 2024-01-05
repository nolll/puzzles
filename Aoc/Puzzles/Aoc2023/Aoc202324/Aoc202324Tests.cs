using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202324;

public class Aoc202324Tests
{
    [Test]
    public void CountIntersecting()
    {
        const string input = """
                             19, 13, 30 @ -2,  1, -2
                             18, 19, 22 @ -1, -1, -2
                             20, 25, 34 @ -2, -2, -4
                             12, 31, 28 @ -1, -2, -1
                             20, 19, 15 @  1, -5, -3
                             """;

        var result = Aoc202324.CountIntersectingWithin(input, 7, 27);

        result.Should().Be(2);
    }
}
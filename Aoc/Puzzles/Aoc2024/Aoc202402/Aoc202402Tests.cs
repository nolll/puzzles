using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202402;

public class Aoc202402Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             7 6 4 2 1
                             1 2 7 8 9
                             9 7 6 2 1
                             1 3 2 4 5
                             8 6 4 4 1
                             1 3 6 7 9
                             """;

        var result = Sut.Part1(input);
        result.Answer.Should().Be("2");
    }

    private static Aoc202402 Sut => new();
}
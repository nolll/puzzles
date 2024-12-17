using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202417;

public class Aoc202417Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             Register A: 729
                             Register B: 0
                             Register C: 0
                             
                             Program: 0,1,5,4,3,0
                             """;

        Sut.Part1(input).Answer.Should().Be("4,6,3,5,6,3,5,2,1,0");
    }

    [Test]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Answer.Should().Be("0");
    }

    private static Aoc202417 Sut => new();
}
using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202422;

public class Aoc202422Tests
{
    [TestCase(1, 15887950)]
    [TestCase(2, 16495136)]
    [TestCase(3, 527345)]
    [TestCase(4, 704524)]
    [TestCase(5, 1553684)]
    [TestCase(6, 12683156)]
    [TestCase(7, 11100544)]
    [TestCase(8, 12249484)]
    [TestCase(9, 7753432)]
    [TestCase(10, 5908254)]
    public void Generate(int iterations, long expected) => Sut.Generate(123, iterations).Should().Be(expected);

    [Test]
    public void Part1()
    {
        const string input = """
                             1
                             10
                             100
                             2024
                             """;

        Sut.Part1(input).Answer.Should().Be("37327623");
    }
    
    [Test]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Answer.Should().Be("0");
    }

    private static Aoc202422 Sut => new();
}
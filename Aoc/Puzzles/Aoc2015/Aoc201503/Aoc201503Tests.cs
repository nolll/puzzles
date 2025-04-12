using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201503;

public class Aoc201503Tests
{
    [TestCase(">", "2")]
    [TestCase("^>v<", "4")]
    [TestCase("^v^v^v^v^v", "2")]
    public void DeliversToCorrectNumberOfHouses_Santa(string input, string expected) => 
        Sut.Part1(input).Answer.Should().Be(expected);

    [TestCase("^v", "3")]
    [TestCase("^>v<", "3")]
    [TestCase("^v^v^v^v^v", "11")]
    public void DeliversToCorrectNumberOfHouses_SantaAndRobot(string input, string expected) => 
        Sut.Part2(input).Answer.Should().Be(expected);

    private static Aoc201503 Sut => new();
}
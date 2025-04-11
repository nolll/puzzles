using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201501;

public class Aoc201501Tests
{
    [TestCase("(())", 0)]
    [TestCase("()()", 0)]
    [TestCase("(((", 3)]
    [TestCase("(()(()(", 3)]
    [TestCase("))(((((", 3)]
    [TestCase("())", -1)]
    [TestCase("))(", -1)]
    [TestCase(")))", -3)]
    [TestCase(")())())", -3)]
    public void Part1(string input, int expected) => Sut.Part1(input).Answer.Should().Be(expected.ToString());

    [TestCase(")", 1)]
    [TestCase("()())", 5)]
    public void Part2(string input, int expected) => Sut.Part2(input).Answer.Should().Be(expected.ToString());
    
    private static Aoc201501 Sut => new();
}
using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Numbers;

public class SequenceTests
{
    [TestCase("0 3 6 9 12 15", 18)]
    [TestCase("1 3 6 10 15 21", 28)]
    [TestCase("10 13 16 21 30 45", 68)]
    [TestCase("-1 -2 -3 -4 -5 -6", -7)]
    public void NextNumber(string input, long expected)
    {
        var result = Sequence.Next(input.Split(' ').Select(long.Parse));

        result.Should().Be(expected);
    }

    [TestCase("0 3 6 9 12 15", -3)]
    [TestCase("1 3 6 10 15 21", 0)]
    [TestCase("10 13 16 21 30 45", 5)]
    [TestCase("-1 -2 -3 -4 -5 -6", 0)]
    public void PrevNumber(string input, long expected)
    {
        var result = Sequence.Previous(input.Split(' ').Select(long.Parse));

        result.Should().Be(expected);
    }
}
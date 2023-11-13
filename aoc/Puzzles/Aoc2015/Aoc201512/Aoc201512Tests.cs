using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2015.Aoc201512;

public class Aoc201512Tests
{
    [TestCase("[1,2,3]", 6)]
    [TestCase("{\"a\":2,\"b\":4}", 6)]
    [TestCase("[[[3]]]", 3)]
    [TestCase("{\"a\":{\"b\":4},\"c\":-1}", 3)]
    [TestCase("{\"a\":[-1,1]}", 0)]
    [TestCase("[-1,{\"a\":1}]", 0)]
    [TestCase("[]", 0)]
    [TestCase("{}", 0)]
    public void CalculatesTheSumOfAllNumbers(string input, int expected)
    {
        var doc = new JsonDoc(input, true);

        doc.Sum.Should().Be(expected);
    }
}
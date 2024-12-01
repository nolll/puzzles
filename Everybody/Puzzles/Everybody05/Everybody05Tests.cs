using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody05;

public class Everybody05Tests
{
    [TestCase(1, "3345")]
    [TestCase(2, "3245")]
    [TestCase(3, "3255")]
    [TestCase(4, "3252")]
    [TestCase(5, "4252")]
    [TestCase(6, "4452")]
    [TestCase(7, "4422")]
    [TestCase(8, "4423")]
    [TestCase(9, "2423")]
    [TestCase(10, "2323")]
    public void Part1(int rounds, string expected)
    {
        const string input = """
                             2 3 4 5
                             3 4 5 2
                             4 5 2 3
                             5 2 3 4
                             """;

        Everybody05.RunPart1(input, rounds).Should().Be(expected);
    }
    
    [Test]
    public void Part2()
    {
        const string input = """
                             2 3 4 5
                             6 7 8 9
                             """;

        Everybody05.RunPart2(input, 2024).Should().Be(50877075);
    }
    
    [Test]
    public void Part3()
    {
        const string input = """
                             2 3 4 5
                             6 7 8 9
                             """;

        Everybody05.Part3(input).Should().Be(6584);
    }
}
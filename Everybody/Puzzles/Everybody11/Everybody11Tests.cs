using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody11;

public class Everybody11Tests
{
    [TestCase(1, 2)]
    [TestCase(2, 3)]
    [TestCase(3, 5)]
    [TestCase(4, 8)]
    public void Part1And2(int days, int expected)
    {
        const string input = """
                             A:B,C
                             B:C,A
                             C:A
                             """;

        Sut.Solve(input, "A", days).Should().Be(expected);
    }

    [Test]
    public void Part3()
    {
        const string input = """
                             A:B,C
                             B:C,A,A
                             C:A
                             """;

        Sut.Part3(input).Answer.Should().Be("268815");
    }

    private static Everybody11 Sut => new();
}
using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202417;

public class Ece202417Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             *...*
                             ..*..
                             .....
                             .....
                             *.*..
                             """;

        Sut.Part1(input).Answer.Should().Be("16");
    }

    [Test]
    public void Part3()
    {
        const string input = """
                             .......................................
                             ..*.......*...*.....*...*......**.**...
                             ....*.................*.......*..*..*..
                             ..*.........*.......*...*.....*.....*..
                             ......................*........*...*...
                             ..*.*.....*...*.....*...*........*.....
                             .......................................
                             """;

        Sut.Part3(input).Answer.Should().Be("15624");
    }

    private static Ece202417 Sut => new();
}
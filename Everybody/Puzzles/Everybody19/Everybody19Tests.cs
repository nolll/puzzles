using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody19;

public class Everybody19Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             LR
                             
                             >-IN-
                             -----
                             W---<
                             """;

        Sut.Part1(input).Answer.Should().Be("WIN");
    }

    [Test]
    public void Part2()
    {
        const string input = """
                             RRLL
                             
                             A.VI..>...T
                             .CC...<...O
                             .....EIB.R.
                             .DHB...YF..
                             .....F..G..
                             D.H........
                             """;

        Sut.Part2(input).Answer.Should().Be("VICTORY");
    }

    [Test]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Answer.Should().Be("0");
    }

    private static Everybody19 Sut => new();
}
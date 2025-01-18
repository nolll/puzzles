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
    public void Part1_Details()
    {
        const string input = """
                             LR

                             >aINb
                             cdefg
                             Whij<
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
    
    private static Everybody19 Sut => new();
}
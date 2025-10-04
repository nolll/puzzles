using FluentAssertions;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202419;

public class Ece202419Tests
{
    [Fact]
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
    
    [Fact]
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

    [Fact]
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
    
    private static Ece202419 Sut => new();
}
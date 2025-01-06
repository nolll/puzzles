using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody14;

public class Everybody14Tests
{
    [Test]
    public void Part1()
    {
        const string input = "U5,R3,D2,L5,U4,R5,D2";

        Sut.Part1(input).Answer.Should().Be("7");
    }

    [Test]
    public void Part2()
    {
        const string input = """
                             U5,R3,D2,L5,U4,R5,D2
                             U6,L1,D2,R3,U2,L1
                             """;

        Sut.Part2(input).Answer.Should().Be("32");
    }

    [Test]
    public void Part3_1()
    {
        const string input = """
                             U5,R3,D2,L5,U4,R5,D2
                             U6,L1,D2,R3,U2,L1
                             """;

        Sut.Part3(input).Answer.Should().Be("5");
    }
    
    [Test]
    public void Part3_2()
    {
        const string input = """
                             U20,L1,B1,L2,B1,R2,L1,F1,U1
                             U10,F1,B1,R1,L1,B1,L1,F1,R2,U1
                             U30,L2,F1,R1,B1,R1,F2,U1,F1
                             U25,R1,L2,B1,U1,R2,F1,L2
                             U16,L1,B1,L1,B3,L1,B1,F1
                             """;

        Sut.Part3(input).Answer.Should().Be("46");
    }

    private static Everybody14 Sut => new();
}
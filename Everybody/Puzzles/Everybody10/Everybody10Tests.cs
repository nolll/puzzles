using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody10;

public class Everybody10Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             **PCBS**
                             **RLNW**
                             BV....PT
                             CR....HZ
                             FL....JW
                             SG....MN
                             **FTZV**
                             **GMJH**
                             """;

        Sut.Part1(input).Answer.Should().Be("PTBVRCZHFLJWGMNS");
    }
    
    [Test]
    public void GetScore()
    {
        const string input = "PTBVRCZHFLJWGMNS";

        Sut.GetScore(input).Should().Be(1851);
    }

    private static Everybody10 Sut => new();
}
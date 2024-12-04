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

        Everybody10.GetScore(input).Should().Be(1851);
    }
    
    [Test]
    public void Part3()
    {
        const string input = """
                             **XFZB**DCST**
                             **LWQK**GQJH**
                             ?G....WL....DQ
                             BS....H?....CN
                             P?....KJ....TV
                             NM....Z?....SG
                             **NSHM**VKWZ**
                             **PJGV**XFNL**
                             WQ....?L....YS
                             FX....DJ....HV
                             ?Y....WM....?J
                             TJ....YK....LP
                             **XRTK**BMSP**
                             **DWZN**GCJV**
                             """;

        Sut.Part3(input).Answer.Should().Be("3889");
    }

    private static Everybody10 Sut => new();
}
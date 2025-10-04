using FluentAssertions;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202410;

public class Ece202410Tests
{
    [Fact]
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
    
    [Fact]
    public void GetScore()
    {
        const string input = "PTBVRCZHFLJWGMNS";

        Ece202410.GetScore(input).Should().Be(1851);
    }
    
    [Fact]
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

    private static Ece202410 Sut => new();
}
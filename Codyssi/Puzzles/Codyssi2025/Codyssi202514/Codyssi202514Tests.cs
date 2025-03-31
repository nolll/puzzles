using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202514;

public class Codyssi202514Tests
{
    private const string Input = """
                                 1 ETdhCGi | Quality : 36, Cost : 25, Unique Materials : 7
                                 2 GWgcpkv | Quality : 38, Cost : 17, Unique Materials : 25
                                 3 ODVdJYM | Quality : 1, Cost : 1, Unique Materials : 26
                                 4 wTdbhEr | Quality : 23, Cost : 10, Unique Materials : 18
                                 5 hoOYtHQ | Quality : 25, Cost : 15, Unique Materials : 27
                                 6 jxRouXI | Quality : 31, Cost : 17, Unique Materials : 7
                                 7 dOXpCyA | Quality : 23, Cost : 2, Unique Materials : 28
                                 8 LtCtwHO | Quality : 37, Cost : 26, Unique Materials : 29
                                 9 DLxTAif | Quality : 32, Cost : 24, Unique Materials : 1
                                 10 XCUJAZF | Quality : 22, Cost : 25, Unique Materials : 29
                                 11 cwoqgJA | Quality : 38, Cost : 28, Unique Materials : 7
                                 12 ROPdFSh | Quality : 41, Cost : 29, Unique Materials : 15
                                 13 iYypXES | Quality : 37, Cost : 12, Unique Materials : 15
                                 14 srwmKYA | Quality : 48, Cost : 25, Unique Materials : 14
                                 15 xRbzjOM | Quality : 36, Cost : 20, Unique Materials : 21
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("90");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("8256");

    [Test]
    public void Part3() => Sut.RunPart2And3(Input, 150).Should().Be(59388);

    private static Codyssi202514 Sut => new();
}
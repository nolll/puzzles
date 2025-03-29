using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202513;

public class Codyssi202513Tests
{
    private const string Input = """
                                 STT -> MFP | 5
                                 AIB -> ZGK | 6
                                 ZGK -> KVX | 20
                                 STT -> AFG | 4
                                 AFG -> ZGK | 16
                                 MFP -> BDD | 13
                                 BDD -> AIB | 5
                                 AXU -> MFP | 4
                                 CLB -> BLV | 20
                                 AIB -> BDD | 13
                                 BLV -> AXU | 17
                                 AFG -> CLB | 2
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("36");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("44720");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("18");

    private static Codyssi202513 Sut => new();
}
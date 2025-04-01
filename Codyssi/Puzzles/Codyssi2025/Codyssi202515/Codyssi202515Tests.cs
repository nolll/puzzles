using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202515;

public class Codyssi202515Tests
{
    private const string Input = """
                                 ozNxANO | 576690
                                 pYNonIG | 323352
                                 MUantNm | 422646
                                 lOSlxki | 548306
                                 SDJtdpa | 493637
                                 ocWkKQi | 747973
                                 qfSKloT | 967749
                                 KGRZQKg | 661714
                                 JSXfNAJ | 499862
                                 LnDiFPd | 55528
                                 FyNcJHX | 9047
                                 UfWSgzb | 200543
                                 PtRtdSE | 314969
                                 gwHsSzH | 960026
                                 JoyLmZv | 833936
                                 
                                 MUantNm | 422646
                                 FyNcJHX | 9047
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("12645822");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("0");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("0");

    private static Codyssi202515 Sut => new();
}
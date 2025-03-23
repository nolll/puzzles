using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202507;

public class Codyssi202507Tests
{
    private const string Input = """
                                 159
                                 527
                                 827
                                 596
                                 296
                                 413
                                 45
                                 796
                                 853
                                 778
                                 
                                 4-8
                                 5-8
                                 10-1
                                 6-5
                                 2-1
                                 6-5
                                 8-7
                                 3-6
                                 7-8
                                 2-10
                                 6-4
                                 8-10
                                 1-9
                                 3-6
                                 7-10
                                 
                                 10
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("45");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("796");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("827");

    private static Codyssi202507 Sut => new();
}
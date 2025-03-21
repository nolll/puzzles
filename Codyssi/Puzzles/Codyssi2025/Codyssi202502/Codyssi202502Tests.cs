using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202502;

public class Codyssi202502Tests
{
    private const string Input = """
                                 Function A: ADD 495
                                 Function B: MULTIPLY 55
                                 Function C: RAISE TO THE POWER OF 3

                                 5219
                                 8933
                                 3271
                                 7128
                                 9596
                                 9407
                                 7005
                                 1607
                                 4084
                                 4525
                                 5496
                                 """;

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("9130674516975");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("1000986169836015");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("5496");

    private static Codyssi202502 Sut => new();
}
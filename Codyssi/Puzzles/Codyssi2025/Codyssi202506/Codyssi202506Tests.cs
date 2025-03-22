using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202506;

public class Codyssi202506Tests
{
    private const string Input = "t#UD$%%DVd*L?^p?S$^@#@@$pF$?xYJ$LLv$@%EXO&$*iSFZuT!^VMHy#zKISHaBj?e*#&yRVdemc#?&#Q%j&ev*#YWRi@?mNQ@eK";

    [Test]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("59");

    [Test]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("1742");

    [Test]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("2708");

    private static Codyssi202506 Sut => new();
}
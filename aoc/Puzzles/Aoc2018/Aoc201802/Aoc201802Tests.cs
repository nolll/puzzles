using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2018.Aoc201802;

public class Aoc201802Tests
{
    [Test]
    public void NoSimilarIds()
    {
        var ids = new List<string> { "abcde", "fghij" };
        var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
        similarIds.Count.Should().Be(0);
    }

    [Test]
    public void EqualIdsIds_ReturnsNoMatch()
    {
        var ids = new List<string> { "abcde", "abcde" };
        var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
        similarIds.Count.Should().Be(0);
    }

    [Test]
    public void OneSimilarId()
    {
        var ids = new List<string> { "abcde", "abcdX" };
        var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
        similarIds.Count.Should().Be(2);
    }

    [Test]
    public void TwoSimilarIds_ReturnsOnlyFirstMatch()
    {
        var ids = new List<string> { "abcde", "abcdX", "fghij", "fghiX" };
        var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
        similarIds.Count.Should().Be(2);
    }

    [Test]
    public void HandleProvidedExample()
    {
        const string ids = "abcdef\nbababc\nabbcde\nabcccd\naabcdd\nabcdee\nababab";
        var puzzle = new BoxChecksumPuzzle(ids);
        puzzle.Checksum.Should().Be(12);
    }

    [Test]
    public void AllLettersCommon()
    {
        const string str = "abcde";
        var commonLetters = SimilarIdsPuzzle.GetCommonLetters(str, str);
        commonLetters.Should().Be("abcde");
    }

    [Test]
    public void NoLettersCommon()
    {
        const string str1 = "abcde";
        const string str2 = "fghij";
        var commonLetters = SimilarIdsPuzzle.GetCommonLetters(str1, str2);
        commonLetters.Should().Be("");
    }

    [Test]
    public void ThreeLettersCommon()
    {
        const string str1 = "abcde";
        const string str2 = "aXcYe";
        var commonLetters = SimilarIdsPuzzle.GetCommonLetters(str1, str2);
        commonLetters.Should().Be("ace");
    }
}
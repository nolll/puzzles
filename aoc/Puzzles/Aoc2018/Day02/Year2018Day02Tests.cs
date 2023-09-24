using System.Collections.Generic;
using NUnit.Framework;

namespace Aoc.Puzzles.Year2018.Day02;

public class Year2018Day02Tests
{
    [Test]
    public void NoSimilarIds()
    {
        var ids = new List<string> { "abcde", "fghij" };
        var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
        Assert.AreEqual(0, similarIds.Count);
    }

    [Test]
    public void EqualIdsIds_ReturnsNoMatch()
    {
        var ids = new List<string> { "abcde", "abcde" };
        var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
        Assert.AreEqual(0, similarIds.Count);
    }

    [Test]
    public void OneSimilarId()
    {
        var ids = new List<string> { "abcde", "abcdX" };
        var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
        Assert.AreEqual(2, similarIds.Count);
    }

    [Test]
    public void TwoSimilarIds_ReturnsOnlyFirstMatch()
    {
        var ids = new List<string> { "abcde", "abcdX", "fghij", "fghiX" };
        var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
        Assert.AreEqual(2, similarIds.Count);
    }

    [Test]
    public void HandleProvidedExample()
    {
        const string ids = "abcdef\nbababc\nabbcde\nabcccd\naabcdd\nabcdee\nababab";
        var puzzle = new BoxChecksumPuzzle(ids);
        Assert.AreEqual(12, puzzle.Checksum);
    }

    [Test]
    public void AllLettersCommon()
    {
        const string str = "abcde";
        var commonLetters = SimilarIdsPuzzle.GetCommonLetters(str, str);
        Assert.AreEqual("abcde", commonLetters);
    }

    [Test]
    public void NoLettersCommon()
    {
        const string str1 = "abcde";
        const string str2 = "fghij";
        var commonLetters = SimilarIdsPuzzle.GetCommonLetters(str1, str2);
        Assert.AreEqual("", commonLetters);
    }

    [Test]
    public void ThreeLettersCommon()
    {
        const string str1 = "abcde";
        const string str2 = "aXcYe";
        var commonLetters = SimilarIdsPuzzle.GetCommonLetters(str1, str2);
        Assert.AreEqual("ace", commonLetters);
    }
}
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201802;

public class Aoc201802Tests
{
    [Fact]
    public void NoSimilarIds()
    {
        var ids = new List<string> { "abcde", "fghij" };
        var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
        similarIds.Count.Should().Be(0);
    }

    [Fact]
    public void EqualIdsIds_ReturnsNoMatch()
    {
        var ids = new List<string> { "abcde", "abcde" };
        var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
        similarIds.Count.Should().Be(0);
    }

    [Fact]
    public void OneSimilarId()
    {
        var ids = new List<string> { "abcde", "abcdX" };
        var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
        similarIds.Count.Should().Be(2);
    }

    [Fact]
    public void TwoSimilarIds_ReturnsOnlyFirstMatch()
    {
        var ids = new List<string> { "abcde", "abcdX", "fghij", "fghiX" };
        var similarIds = SimilarIdsPuzzle.GetSimilarIds(ids);
        similarIds.Count.Should().Be(2);
    }

    [Fact]
    public void HandleProvidedExample()
    {
        const string ids = "abcdef bababc abbcde abcccd aabcdd abcdee ababab";
        var puzzle = new BoxChecksumPuzzle(SpacesToNewLines(ids));
        puzzle.Checksum.Should().Be(12);
    }

    [Fact]
    public void AllLettersCommon()
    {
        const string str = "abcde";
        var commonLetters = SimilarIdsPuzzle.GetCommonLetters(str, str);
        commonLetters.Should().Be("abcde");
    }

    [Fact]
    public void NoLettersCommon()
    {
        const string str1 = "abcde";
        const string str2 = "fghij";
        var commonLetters = SimilarIdsPuzzle.GetCommonLetters(str1, str2);
        commonLetters.Should().Be("");
    }

    [Fact]
    public void ThreeLettersCommon()
    {
        const string str1 = "abcde";
        const string str2 = "aXcYe";
        var commonLetters = SimilarIdsPuzzle.GetCommonLetters(str1, str2);
        commonLetters.Should().Be("ace");
    }

    private string SpacesToNewLines(string input) => input.Replace(" ", LineBreaks.Single);
}
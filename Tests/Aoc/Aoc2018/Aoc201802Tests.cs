using Pzl.Aoc.Puzzles.Aoc2018;
using Pzl.Tools.Strings;

namespace Tests.Aoc.Aoc2018;

public class Aoc201802Tests : PuzzleTest<Aoc201802>
{
    [Fact]
    public void NoSimilarIds() => Sut.GetSimilarIds(["abcde", "fghij"]).Count.Should().Be(0);

    [Fact]
    public void EqualIdsIds_ReturnsNoMatch() => Sut.GetSimilarIds(["abcde", "abcde"]).Count.Should().Be(0);

    [Fact]
    public void OneSimilarId() => Sut.GetSimilarIds(["abcde", "abcdX"]).Count.Should().Be(2);

    [Fact]
    public void TwoSimilarIds_ReturnsOnlyFirstMatch() =>
        Sut.GetSimilarIds(["abcde", "abcdX", "fghij", "fghiX"]).Count.Should().Be(2);

    [Fact]
    public void HandleProvidedExample() => 
        Sut.Part1(SpacesToNewLines("abcdef bababc abbcde abcccd aabcdd abcdee ababab")).Should().Be(12);

    [Fact]
    public void AllLettersCommon() => Sut.GetCommonLetters("abcde", "abcde").Should().Be("abcde");

    [Fact]
    public void NoLettersCommon() => Sut.GetCommonLetters("abcde", "fghij").Should().Be("");

    [Fact]
    public void ThreeLettersCommon() => Sut.GetCommonLetters("abcde", "aXcYe").Should().Be("ace");
}
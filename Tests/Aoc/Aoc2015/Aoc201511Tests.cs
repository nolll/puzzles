using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201511Tests : PuzzleTest<Aoc201511>
{
    [Theory]
    [InlineData("hijklmmn", false)]
    [InlineData("abbceffg", false)]
    [InlineData("abbcegjk", false)]
    [InlineData("abckkmmn", true)]
    public void ValidatePasswords(string pwd, bool expected) => Sut.IsValid(pwd).Should().Be(expected);

    [Theory]
    [InlineData("abcdefgh", "abcdffaa")]
    [InlineData("ghijklmn", "ghjaabcc")]
    public void FindsNextPassword(string pwd, string expected) => Sut.Part1(pwd).Should().Be(expected);
}
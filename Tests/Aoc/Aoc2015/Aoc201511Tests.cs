using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201511Tests
{
    [Theory]
    [InlineData("hijklmmn", false)]
    [InlineData("abbceffg", false)]
    [InlineData("abbcegjk", false)]
    [InlineData("abckkmmn", true)]
    public void ValidatePasswords(string pwd, bool expected) => 
        Aoc201511.CorporatePasswordValidator.IsValid(pwd).Should().Be(expected);

    [Theory]
    [InlineData("abcdefgh", "abcdffaa")]
    [InlineData("ghijklmn", "ghjaabcc")]
    public void FindsNextPassword(string pwd, string expected) => Sut.Part1(pwd).Should().Be(expected);

    private static Aoc201511 Sut => new();
}
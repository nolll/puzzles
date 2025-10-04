namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201511;

public class Aoc201511Tests
{
    [Theory]
    [InlineData("hijklmmn", false)]
    [InlineData("abbceffg", false)]
    [InlineData("abbcegjk", false)]
    [InlineData("abckkmmn", true)]
    public void ValidatePasswords(string pwd, bool expected) => 
        CorporatePasswordValidator.IsValid(pwd).Should().Be(expected);

    [Theory]
    [InlineData("abcdefgh", "abcdffaa")]
    [InlineData("ghijklmn", "ghjaabcc")]
    public void FindsNextPassword(string pwd, string expected) => Sut.Part1(pwd).Answer.Should().Be(expected);

    private static Aoc201511 Sut => new();
}
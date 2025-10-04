namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201704;

public class Aoc201704Tests
{
    [Theory]
    [InlineData("aa bb cc dd ee", true)]
    [InlineData("aa bb cc dd aa", false)]
    [InlineData("aa bb cc dd aaa", true)]
    public void ValidatePassword1(string input, bool expected)
    {
        var validator = new PassphraseValidator();
        var coin = validator.IsValid1(input);

        coin.Should().Be(expected);
    }

    [Theory]
    [InlineData("abcde fghij", true)]
    [InlineData("abcde xyz ecdab", false)]
    [InlineData("a ab abc abd abf abj", true)]
    [InlineData("iiii oiii ooii oooi oooo", true)]
    [InlineData("oiii ioii iioi iiio", false)]
    public void ValidatePassword2(string input, bool expected)
    {
        var validator = new PassphraseValidator();
        var coin = validator.IsValid2(input);

        coin.Should().Be(expected);
    }
}
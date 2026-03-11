namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202002;

public class Aoc202002Tests
{
    [Theory]
    [InlineData("1-3 a: abcde")]
    [InlineData("2-9 c: ccccccccc")]
    public void PasswordIsValidAccordingToRuleOne(string policy) => Sut.IsValidAccordingToRuleOne(policy).Should().BeTrue();

    [Theory]
    [InlineData("1-3 b: cdefg")]
    public void PasswordIsInvalidAccordingToRuleOne(string policy) => Sut.IsValidAccordingToRuleOne(policy).Should().BeFalse();

    [Theory]
    [InlineData("1-3 a: abcde")]
    public void PasswordIsValidAccordingToRuleTwo(string policy) => Sut.IsValidAccordingToRuleTwo(policy).Should().BeTrue();

    [Theory]
    [InlineData("1-3 b: cdefg")]
    [InlineData("2-9 c: ccccccccc")]
    public void PasswordIsInvalidAccordingToRuleTwo(string policy) => Sut.IsValidAccordingToRuleTwo(policy).Should().BeFalse();

    private static Aoc202002 Sut => new();
}
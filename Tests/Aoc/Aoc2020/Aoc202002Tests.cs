using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202002Tests : PuzzleTest<Aoc202002>
{
    [Theory]
    [InlineData("1-3 a: abcde")]
    [InlineData("2-9 c: ccccccccc")]
    public void PasswordIsValidAccordingToRuleOne(string policy) => Aoc202002.IsValidAccordingToRuleOne(policy).Should().BeTrue();

    [Theory]
    [InlineData("1-3 b: cdefg")]
    public void PasswordIsInvalidAccordingToRuleOne(string policy) => Aoc202002.IsValidAccordingToRuleOne(policy).Should().BeFalse();

    [Theory]
    [InlineData("1-3 a: abcde")]
    public void PasswordIsValidAccordingToRuleTwo(string policy) => Aoc202002.IsValidAccordingToRuleTwo(policy).Should().BeTrue();

    [Theory]
    [InlineData("1-3 b: cdefg")]
    [InlineData("2-9 c: ccccccccc")]
    public void PasswordIsInvalidAccordingToRuleTwo(string policy) => Aoc202002.IsValidAccordingToRuleTwo(policy).Should().BeFalse();
}
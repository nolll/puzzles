using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202002Tests : PuzzleTest<Aoc202002>
{
    [Theory]
    [InlineData("1-3 a: abcde")]
    [InlineData("2-9 c: ccccccccc")]
    public void PasswordIsValidAccordingToRuleOne(string policy) => Sut.IsValid1(policy).Should().BeTrue();

    [Theory]
    [InlineData("1-3 b: cdefg")]
    public void PasswordIsInvalidAccordingToRuleOne(string policy) => Sut.IsValid1(policy).Should().BeFalse();

    [Theory]
    [InlineData("1-3 a: abcde")]
    public void PasswordIsValidAccordingToRuleTwo(string policy) => Sut.IsValid2(policy).Should().BeTrue();

    [Theory]
    [InlineData("1-3 b: cdefg")]
    [InlineData("2-9 c: ccccccccc")]
    public void PasswordIsInvalidAccordingToRuleTwo(string policy) => Sut.IsValid2(policy).Should().BeFalse();
}
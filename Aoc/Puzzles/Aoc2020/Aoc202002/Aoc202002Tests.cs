using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202002;

public class Aoc202002Tests
{
    [TestCase("1-3 a: abcde")]
    [TestCase("2-9 c: ccccccccc")]
    public void PasswordIsValidAccordingToRuleOne(string policy)
    {
        var policyValidator = new PasswordPolicyValidator();
        var result = policyValidator.IsValidAccordingToRuleOne(policy);

        result.Should().BeTrue();
    }

    [TestCase("1-3 b: cdefg")]
    public void PasswordIsInvalidAccordingToRuleOne(string policy)
    {
        var policyValidator = new PasswordPolicyValidator();
        var result = policyValidator.IsValidAccordingToRuleOne(policy);

        result.Should().BeFalse();
    }

    [TestCase("1-3 a: abcde")]
    public void PasswordIsValidAccordingToRuleTwo(string policy)
    {
        var policyValidator = new PasswordPolicyValidator();
        var result = policyValidator.IsValidAccordingToRuleTwo(policy);

        result.Should().BeTrue();
    }

    [TestCase("1-3 b: cdefg")]
    [TestCase("2-9 c: ccccccccc")]
    public void PasswordIsInvalidAccordingToRuleTwo(string policy)
    {
        var policyValidator = new PasswordPolicyValidator();
        var result = policyValidator.IsValidAccordingToRuleTwo(policy);

        result.Should().BeFalse();
    }

}
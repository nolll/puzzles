using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201904;

public class Aoc201904Tests
{
    [TestCase(112233)]
    [TestCase(111122)]
    public void PasswordIsValid(int pwd)
    {
        var passwordValidator = new PasswordValidator();
        var result = passwordValidator.IsValidPart2(pwd);

        result.Should().BeTrue();
    }

    [TestCase(111111)]
    [TestCase(223450)]
    [TestCase(123789)]
    [TestCase(123444)]
    public void PasswordIsInvalid(int pwd)
    {
        var passwordValidator = new PasswordValidator();
        var result = passwordValidator.IsValidPart2(pwd);

        result.Should().BeFalse();
    }

    [Test]
    public void AllDifferentChars_NoGroupsOfTwo()
    {
        const int pwd = 123789;
        var str = pwd.ToString().ToCharArray();
        var result = PasswordAnalyzer.HasGroupOfTwo(str);

        result.Should().BeFalse();
    }

    [Test]
    public void TwoAdjacentEqualChars_OneGroupsOfTwo()
    {
        const int pwd = 223450;
        var str = pwd.ToString().ToCharArray();
        var result = PasswordAnalyzer.HasGroupOfTwo(str);

        result.Should().BeTrue();
    }

    [Test]
    public void ThreeAdjacentEqualChars_NoGroupsOfTwo()
    {
        const int pwd = 123444;
        var str = pwd.ToString().ToCharArray();
        var result = PasswordAnalyzer.HasGroupOfTwo(str);

        result.Should().BeFalse();
    }
}
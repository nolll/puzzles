using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2019.Day04;

public class Year2019Day04Tests
{
    [TestCase(112233)]
    [TestCase(111122)]
    public void PasswordIsValid(int pwd)
    {
        var passwordValidator = new PasswordValidator();
        var result = passwordValidator.IsValidPart2(pwd);

        Assert.That(result, Is.True);
    }

    [TestCase(111111)]
    [TestCase(223450)]
    [TestCase(123789)]
    [TestCase(123444)]
    public void PasswordIsInvalid(int pwd)
    {
        var passwordValidator = new PasswordValidator();
        var result = passwordValidator.IsValidPart2(pwd);

        Assert.That(result, Is.False);
    }

    [Test]
    public void AllDifferentChars_NoGroupsOfTwo()
    {
        const int pwd = 123789;
        var str = pwd.ToString().ToCharArray();
        var result = PasswordAnalyzer.HasGroupOfTwo(str);

        Assert.That(result, Is.False);
    }

    [Test]
    public void TwoAdjacentEqualChars_OneGroupsOfTwo()
    {
        const int pwd = 223450;
        var str = pwd.ToString().ToCharArray();
        var result = PasswordAnalyzer.HasGroupOfTwo(str);

        Assert.That(result, Is.True);
    }

    [Test]
    public void ThreeAdjacentEqualChars_NoGroupsOfTwo()
    {
        const int pwd = 123444;
        var str = pwd.ToString().ToCharArray();
        var result = PasswordAnalyzer.HasGroupOfTwo(str);

        Assert.That(result, Is.False);
    }
}
namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201904;

public class Aoc201904Tests
{
    [Theory]
    [InlineData(112233)]
    [InlineData(111122)]
    public void PasswordIsValid(int pwd)
    {
        var passwordValidator = new PasswordValidator();
        var result = passwordValidator.IsValidPart2(pwd);

        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(111111)]
    [InlineData(223450)]
    [InlineData(123789)]
    [InlineData(123444)]
    public void PasswordIsInvalid(int pwd)
    {
        var passwordValidator = new PasswordValidator();
        var result = passwordValidator.IsValidPart2(pwd);

        result.Should().BeFalse();
    }

    [Fact]
    public void AllDifferentChars_NoGroupsOfTwo()
    {
        const int pwd = 123789;
        var str = pwd.ToString().ToCharArray();
        var result = PasswordAnalyzer.HasGroupOfTwo(str);

        result.Should().BeFalse();
    }

    [Fact]
    public void TwoAdjacentEqualChars_OneGroupsOfTwo()
    {
        const int pwd = 223450;
        var str = pwd.ToString().ToCharArray();
        var result = PasswordAnalyzer.HasGroupOfTwo(str);

        result.Should().BeTrue();
    }

    [Fact]
    public void ThreeAdjacentEqualChars_NoGroupsOfTwo()
    {
        const int pwd = 123444;
        var str = pwd.ToString().ToCharArray();
        var result = PasswordAnalyzer.HasGroupOfTwo(str);

        result.Should().BeFalse();
    }
}
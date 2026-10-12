using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201904Tests : PuzzleTest<Aoc201904>
{
    [Theory]
    [InlineData(112233)]
    [InlineData(111122)]
    public void PasswordIsValid(int pwd) => Sut.IsValidPart2(pwd).Should().BeTrue();

    [Theory]
    [InlineData(111111)]
    [InlineData(223450)]
    [InlineData(123789)]
    [InlineData(123444)]
    public void PasswordIsInvalid(int pwd) => Sut.IsValidPart2(pwd).Should().BeFalse();

    [Fact]
    public void AllDifferentChars_NoGroupsOfTwo() => HasGroupOfTwo(123789).Should().BeFalse();

    [Fact]
    public void TwoAdjacentEqualChars_OneGroupsOfTwo() => HasGroupOfTwo(223450).Should().BeTrue();

    [Fact]
    public void ThreeAdjacentEqualChars_NoGroupsOfTwo() => HasGroupOfTwo(123444).Should().BeFalse();

    private static bool HasGroupOfTwo(int n) => Sut.HasGroupOfTwo(n.ToString().ToCharArray());
}
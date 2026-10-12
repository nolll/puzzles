using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201901Tests : PuzzleTest<Aoc201901>
{
    [Theory]
    [InlineData("14", 2)]
    [InlineData("1969", 654)]
    [InlineData("100756", 33583)]
    public void RequiredFuelIsCorrect(string input, int expected) => Sut.Part1(input).Should().Be(expected);

    [Theory]
    [InlineData("14", 2)]
    [InlineData("1969", 966)]
    [InlineData("100756", 50346)]
    public void TotalFuelIsCorrect(string input, int expected) => Sut.Part2(input).Should().Be(expected);
}
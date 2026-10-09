using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201811Tests : PuzzleTest<Aoc201811>
{
    [Theory]
    [InlineData(122, 79, 57, -5)]
    [InlineData(217, 196, 39, 0)]
    [InlineData(101, 153, 71, 4)]
    public void SinglePowerLevelIsCorrect(int x, int y, int serialNumber, int expected) => 
        Sut.GetSinglePowerLevel(serialNumber, x, y).Should().Be(expected);

    [Theory]
    [InlineData("18", "90,269,16")]
    [InlineData("42", "232,251,12")]
    public void AnySizePowerLevelIsCorrect(string input, string expected) => 
        Sut.Part2(input).Should().Be(expected);
}
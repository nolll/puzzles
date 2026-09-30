using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201503Tests : PuzzleTest<Aoc201503>
{
    [Theory]
    [InlineData(">", 2)]
    [InlineData("^>v<", 4)]
    [InlineData("^v^v^v^v^v", 2)]
    public void DeliversToCorrectNumberOfHouses_Santa(string input, int expected) => 
        Sut.Part1(input).Should().Be(expected);

    [Theory]
    [InlineData("^v", 3)]
    [InlineData("^>v<", 3)]
    [InlineData("^v^v^v^v^v", 11)]
    public void DeliversToCorrectNumberOfHouses_SantaAndRobot(string input, int expected) => 
        Sut.Part2(input).Should().Be(expected);
}
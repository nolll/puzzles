namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201503;

public class Aoc201503Tests
{
    [Theory]
    [InlineData(">", "2")]
    [InlineData("^>v<", "4")]
    [InlineData("^v^v^v^v^v", "2")]
    public void DeliversToCorrectNumberOfHouses_Santa(string input, string expected) => 
        Sut.Part1(input).Answer.Should().Be(expected);

    [Theory]
    [InlineData("^v", "3")]
    [InlineData("^>v<", "3")]
    [InlineData("^v^v^v^v^v", "11")]
    public void DeliversToCorrectNumberOfHouses_SantaAndRobot(string input, string expected) => 
        Sut.Part2(input).Answer.Should().Be(expected);

    private static Aoc201503 Sut => new();
}
namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201601;

public class Aoc201601Tests
{
    [Theory]
    [InlineData("R2, L3", 5)]
    [InlineData("R2, R2, R2", 2)]
    [InlineData("R5, L5, R5, R3", 12)]
    public void ManhattanDistanceToTargetIsCorrect(string input, int expected)
    {
        var calc = new EasterbunnyDistanceCalculator();
        calc.Go(input);

        calc.DistanceToTarget.Should().Be(expected);
    }
}
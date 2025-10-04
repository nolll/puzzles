namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201613;

public class Aoc201613Tests
{
    [Fact]
    public void ShortestStepCountIsCorrect()
    {
        const int input = 10;

        var maze = new Maze(10, 7, input);
        var stepCount = maze.StepCountToTarget(7, 4);
        stepCount.Should().Be(11);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 3)]
    [InlineData(2, 5)]
    [InlineData(3, 6)]
    [InlineData(4, 9)]
    public void LocationCountIsCorrect(int steps, int expected)
    {
        const int input = 10;

        var maze = new Maze(10, 7, input);
        var stepCount = maze.LocationCountAfter(steps);
        stepCount.Should().Be(expected);
    }
}
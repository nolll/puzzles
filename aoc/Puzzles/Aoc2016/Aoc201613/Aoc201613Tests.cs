using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2016.Aoc201613;

public class Aoc201613Tests
{
    [Test]
    public void ShortestStepCountIsCorrect()
    {
        const int input = 10;

        var maze = new Maze(10, 7, input);
        var stepCount = maze.StepCountToTarget(7, 4);
        stepCount.Should().Be(11);
    }

    [TestCase(0, 1)]
    [TestCase(1, 3)]
    [TestCase(2, 5)]
    [TestCase(3, 6)]
    [TestCase(4, 9)]
    public void LocationCountIsCorrect(int steps, int expected)
    {
        const int input = 10;

        var maze = new Maze(10, 7, input);
        var stepCount = maze.LocationCountAfter(steps);
        stepCount.Should().Be(expected);
    }
}
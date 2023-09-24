using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2016.Day13;

public class Year2016Day13Tests
{
    [Test]
    public void ShortestStepCountIsCorrect()
    {
        const int input = 10;

        var maze = new Maze(10, 7, input);
        var stepCount = maze.StepCountToTarget(7, 4);
        Assert.That(stepCount, Is.EqualTo(11));
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
        Assert.That(stepCount, Is.EqualTo(expected));
    }
}
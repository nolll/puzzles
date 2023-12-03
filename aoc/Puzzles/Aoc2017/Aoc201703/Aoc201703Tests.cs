using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2017.Aoc201703;

public class Aoc201703Tests
{
    [TestCase(1, 0)]
    [TestCase(12, 3)]
    [TestCase(23, 2)]
    [TestCase(1024, 31)]
    public void NumberOfStepsIsCorrect(int targetSquare, int expectedSteps)
    {
        var spiralMemory = new SpiralMemory(targetSquare, SpiralMemoryMode.RunToTarget);

        spiralMemory.Distance.Should().Be(expectedSteps);
    }
}
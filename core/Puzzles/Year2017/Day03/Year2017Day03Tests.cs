using NUnit.Framework;

namespace Core.Puzzles.Year2017.Day03;

public class Year2017Day03Tests
{
    [TestCase(1, 0)]
    [TestCase(12, 3)]
    [TestCase(23, 2)]
    [TestCase(1024, 31)]
    public void NumberOfStepsIsCorrect(int targetSquare, int expectedSteps)
    {
        var spiralMemory = new SpiralMemory(targetSquare, SpiralMemoryMode.RunToTarget);

        Assert.That(spiralMemory.Distance, Is.EqualTo(expectedSteps));
    }
}
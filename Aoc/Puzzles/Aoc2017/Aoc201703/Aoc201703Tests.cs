namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201703;

public class Aoc201703Tests
{
    [Theory]
    [InlineData(1, 0)]
    [InlineData(12, 3)]
    [InlineData(23, 2)]
    [InlineData(1024, 31)]
    public void NumberOfStepsIsCorrect(int targetSquare, int expectedSteps)
    {
        var spiralMemory = new SpiralMemory(targetSquare, SpiralMemoryMode.RunToTarget);

        spiralMemory.Distance.Should().Be(expectedSteps);
    }
}
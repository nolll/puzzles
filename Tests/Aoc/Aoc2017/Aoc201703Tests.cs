using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201703Tests : PuzzleTest<Aoc201703>
{
    [Theory]
    [InlineData(1, 0)]
    [InlineData(12, 3)]
    [InlineData(23, 2)]
    [InlineData(1024, 31)]
    public void NumberOfStepsIsCorrect(int targetSquare, int expectedSteps)
    {
        var spiralMemory = new Aoc201703.SpiralMemory(targetSquare, Aoc201703.SpiralMemoryMode.RunToTarget);

        spiralMemory.Distance.Should().Be(expectedSteps);
    }
}
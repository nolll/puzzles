using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201613Tests : PuzzleTest<Aoc201613>
{
    private const int Input = 10;
    private const int Width = 10;
    private const int Height = 10;

    [Fact]
    public void ShortestStepCountIsCorrect() => 
        Sut.StepCountToTarget(Width, Height, Input, 7, 4).Should().Be(11);

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 3)]
    [InlineData(2, 5)]
    [InlineData(3, 6)]
    [InlineData(4, 9)]
    public void LocationCountIsCorrect(int steps, int expected) => 
        Sut.LocationCountAfter(Width, Height, Input, steps).Should().Be(expected);
}
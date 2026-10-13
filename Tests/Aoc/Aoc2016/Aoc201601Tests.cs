using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201601Tests : PuzzleTest<Aoc201601>
{
    [Theory]
    [InlineData("R2, L3", 5)]
    [InlineData("R2, R2, R2", 2)]
    [InlineData("R5, L5, R5, R3", 12)]
    public void ManhattanDistanceToTargetIsCorrect(string input, int expected) => 
        Sut.Part1(input).Should().Be(expected);
}
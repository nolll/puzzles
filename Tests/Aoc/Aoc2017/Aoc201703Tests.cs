using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201703Tests : PuzzleTest<Aoc201703>
{
    [Theory]
    [InlineData("1", 0)]
    [InlineData("12", 3)]
    [InlineData("23", 2)]
    [InlineData("1024", 31)]
    public void NumberOfStepsIsCorrect(string input, int expected) => Sut.Part1(input).Should().Be(expected);
}
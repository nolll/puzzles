using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq03Tests : PuzzleTest<Aquaq03>
{
    [Theory]
    [InlineData("UDRR", 14)]
    [InlineData("RR", 6)]
    public void ShouldEndAt(string input, int expectedSum) => Sut.Solve(input).Should().Be(expectedSum);
}
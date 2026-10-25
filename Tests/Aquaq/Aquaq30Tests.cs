using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq30Tests : PuzzleTest<Aquaq30>
{
    [Theory]
    [InlineData("11010", 2)]
    [InlineData("110", 0)]
    [InlineData("00101011010", 3)]
    public void CountValidStartingMoves(string input, int expected) => Sut.CountValidStartingMoves([], input).Should().Be(expected);

    [Theory]
    [InlineData("11010", 0, ".0010")]
    [InlineData("11010", 1, "0.110")]
    [InlineData("11010", 3, "111.1")]
    public void Flip(string input, int index, string expected) => Sut.Flip(input, index).Should().Be(expected);

    [Theory]
    [InlineData(".0010", true)]
    [InlineData("0.110", false)]
    [InlineData("111.1", true)]
    public void CanBeSolved(string input, bool expected) => Sut.CanBeSolved([], input.ToCharArray()).Should().Be(expected);
}
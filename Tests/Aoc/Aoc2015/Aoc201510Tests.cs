using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201510Tests : PuzzleTest<Aoc201510>
{
    [Theory]
    [InlineData("1", "11")]
    [InlineData("11", "21")]
    [InlineData("21", "1211")]
    [InlineData("1211", "111221")]
    [InlineData("111221", "312211")]
    public void CorrectSequence(string input, string expected) => 
        Sut.NextString(input, 1).Should().Be(expected);
}
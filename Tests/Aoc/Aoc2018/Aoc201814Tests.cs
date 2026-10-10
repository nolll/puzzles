using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201814Tests : PuzzleTest<Aoc201814>
{
    [Theory]
    [InlineData("5", "0124515891")]
    [InlineData("9", "5158916779")]
    [InlineData("18", "9251071085")]
    [InlineData("2018", "5941429882")]
    public void FindRecipeScores1(string input, string expected) => Sut.Part1(input).Should().Be(expected);

    [Theory]
    [InlineData("01245", 5)]
    [InlineData("51589", 9)]
    [InlineData("92510", 18)]
    [InlineData("59414", 2018)]
    public void FindRecipeScores2(string input, int expected) => Sut.Part2(input).Should().Be(expected);
}
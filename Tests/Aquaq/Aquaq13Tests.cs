using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq13Tests : PuzzleTest<Aquaq13>
{
    [Theory]
    [InlineData("ABCABCABCABCABC", 5)]
    [InlineData("AAAAAAB", 6)]
    [InlineData("AAAAAABAAAAAB", 6)]
    [InlineData("buhtbuhtbuhtbuhtbuhtbuhtbuhtA", 7)]
    [InlineData("AbuhtbuhtBbuhtbuhtbuhtbuhtbuhtC", 5)]
    public void FindMaxRepeats(string input, int expected) => Sut.Solve(input).Should().Be(expected);
}
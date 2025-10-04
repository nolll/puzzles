namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201501;

public class Aoc201501Tests
{
    [Theory]
    [InlineData("(())", 0)]
    [InlineData("()()", 0)]
    [InlineData("(((", 3)]
    [InlineData("(()(()(", 3)]
    [InlineData("))(((((", 3)]
    [InlineData("())", -1)]
    [InlineData("))(", -1)]
    [InlineData(")))", -3)]
    [InlineData(")())())", -3)]
    public void Part1(string input, int expected) => Sut.Part1(input).Answer.Should().Be(expected.ToString());

    [Theory]
    [InlineData(")", 1)]
    [InlineData("()())", 5)]
    public void Part2(string input, int expected) => Sut.Part2(input).Answer.Should().Be(expected.ToString());
    
    private static Aoc201501 Sut => new();
}
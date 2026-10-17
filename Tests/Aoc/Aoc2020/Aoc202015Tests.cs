using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202015Tests : PuzzleTest<Aoc202015>
{
    [Theory]
    [InlineData("0,3,6", 436)]
    [InlineData("1,3,2", 1)]
    [InlineData("2,1,3", 10)]
    [InlineData("1,2,3", 27)]
    [InlineData("2,3,1", 78)]
    [InlineData("3,2,1", 438)]
    [InlineData("3,1,2", 1836)]
    public void Part1(string input, long expected) => Sut.Part1(input).Should().Be(expected);
    
    [Fact]
    public void Part2() => Sut.Part2("0,3,6").Should().Be(175594);
}
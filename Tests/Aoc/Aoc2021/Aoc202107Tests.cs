using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202107Tests : PuzzleTest<Aoc202107>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(37);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(168);
    
    private const string Input = "16,1,2,0,4,2,7,1,2,14";
}
using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201605Tests : PuzzleTest<Aoc201605>
{
    [Fact]
    public void Part1() => Sut.Part1("abc").Should().Be("18f47a30");

    [Fact]
    public void Part2() => Sut.Part2("abc").Should().Be("05ace8e3");
}
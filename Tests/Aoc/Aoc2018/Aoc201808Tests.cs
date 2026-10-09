using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201808Tests : PuzzleTest<Aoc201808>
{
    private const string Input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(138);

    [Fact]
    public void Part() => Sut.Part2(Input).Should().Be(66);
}
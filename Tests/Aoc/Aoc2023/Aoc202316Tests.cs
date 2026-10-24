using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202316Tests : PuzzleTest<Aoc202316>
{
    private const string Input = """
                                 .|...\....
                                 |.-.\.....
                                 .....|-...
                                 ........|.
                                 ..........
                                 .........\
                                 ..../.\\..
                                 .-.-/..|..
                                 .|....-|.\
                                 ..//.|....
                                 """;

    [Fact]
    public void Part1() => Sut.EnergizedCount(Input).Should().Be(46);

    [Fact]
    public void Part2() => Sut.MostEnergy(Input).Should().Be(51);
}
using Pzl.Aoc.Puzzles.Aoc2024;

namespace Tests.Aoc.Aoc2024;

public class Aoc202406Tests : PuzzleTest<Aoc202406>
{
    private const string Input = """
                                 ....#.....
                                 .........#
                                 ..........
                                 ..#.......
                                 .......#..
                                 ..........
                                 .#..^.....
                                 ........#.
                                 #.........
                                 ......#...
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(41);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(6);

}
using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202316Tests : PuzzleTest<Aoc202316>
{
    [Fact]
    public void Part1()
    {
        const string input = """
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

        var result = Aoc202316.EnergizedCount(input);

        result.Should().Be(46);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
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

        var result = Aoc202316.MostEnergy(input);

        result.Should().Be(51);
    }
}
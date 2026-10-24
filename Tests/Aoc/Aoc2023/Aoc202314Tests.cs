using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202314Tests : PuzzleTest<Aoc202314>
{
    private const string Input = """
                                 O....#....
                                 O.OO#....#
                                 .....##...
                                 OO.#O....O
                                 .O.....O#.
                                 O.#..O.#.#
                                 ..O..#O..O
                                 .......O..
                                 #....###..
                                 #OO..#....
                                 """;

    [Fact]
    public void RollNorth() => Sut.RollNorth(Input).Should().Be(136);

    [Fact]
    public void RunOneCycle()
    {
        const string expected = """
                                .....#....
                                ....#...O#
                                ...OO##...
                                .OO#......
                                .....OOO#.
                                .O#...O#.#
                                ....O#....
                                ......OOOO
                                #...O###..
                                #..OO#....
                                """;

        Sut.RunCycle(Input, 1).Print().Should().Be(expected);
    }

    [Fact]
    public void RunManyCycles() => Sut.RunManyCycles(Input).Should().Be(64);

    [Fact]
    public void RunTwoCycles()
    {
        const string expected = """
                                .....#....
                                ....#...O#
                                .....##...
                                ..O#......
                                .....OOO#.
                                .O#...O#.#
                                ....O#...O
                                .......OOO
                                #..OO###..
                                #.OOO#...O
                                """;

        Sut.RunCycle(Input, 2).Print().Should().Be(expected);
    }
}
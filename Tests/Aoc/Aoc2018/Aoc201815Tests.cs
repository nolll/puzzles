using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201815Tests : PuzzleTest<Aoc201815>
{
    [Fact]
    public void BattleResultsInCorrectOutcome_Case1()
    {
        const string input = """
                             #######
                             #.G...#
                             #...EG#
                             #.#.#G#
                             #..G#E#
                             #.....#
                             #######
                             """;

        Sut.Part1(input).Should().Be(27730);
    }

    [Fact]
    public void BattleResultsInCorrectOutcome_Case2()
    {
        const string input = """
                             #######
                             #G..#E#
                             #E#E.E#
                             #G.##.#
                             #...#E#
                             #...E.#
                             #######
                             """;

        Sut.Part1(input).Should().Be(36334);
    }

    [Fact]
    public void BattleResultsInCorrectOutcome_Case3()
    {
        const string input = """
                             #######
                             #E..EG#
                             #.#G.E#
                             #E.##E#
                             #G..#.#
                             #..E#.#
                             #######
                             """;

        Sut.Part1(input).Should().Be(39514);
    }

    [Fact]
    public void BattleResultsInCorrectOutcome_Case4()
    {
        const string input = """
                             #######
                             #E.G#.#
                             #.#G..#
                             #G.#.G#
                             #G..#.#
                             #...E.#
                             #######
                             """;

        Sut.Part1(input).Should().Be(27755);
    }


    [Fact]
    public void BattleResultsInCorrectOutcome_Case5()
    {
        const string input = """
                             #######
                             #.E...#
                             #.#..G#
                             #.###.#
                             #E#G#G#
                             #...#G#
                             #######
                             """;

        Sut.Part1(input).Should().Be(28944);
    }


    [Fact]
    public void BattleResultsInCorrectOutcome_Case6()
    {
        const string input = """
                             #########
                             #G......#
                             #.E.#...#
                             #..##..G#
                             #...##..#
                             #...#...#
                             #.G...G.#
                             #.....G.#
                             #########
                             """;

        Sut.Part1(input).Should().Be(18740);
    }

    [Fact]
    public void BattleResultsForElvesWinningWithoutLosses_Case1()
    {
        const string input = """
                             #######
                             #.G...#
                             #...EG#
                             #.#.#G#
                             #..G#E#
                             #.....#
                             #######
                             """;

        Sut.Part2(input).Should().Be(4988);
    }

    [Fact]
    public void BattleResultsForElvesWinningWithoutLosses_Case2()
    {
        const string input = """
                             #######
                             #E..EG#
                             #.#G.E#
                             #E.##E#
                             #G..#.#
                             #..E#.#
                             #######
                             """;

        Sut.Part2(input).Should().Be(31284);
    }

    [Fact]
    public void BattleResultsForElvesWinningWithoutLosses_Case3()
    {
        const string input = """
                             #######
                             #E.G#.#
                             #.#G..#
                             #G.#.G#
                             #G..#.#
                             #...E.#
                             #######
                             """;

        Sut.Part2(input).Should().Be(3478);
    }

    [Fact]
    public void BattleResultsForElvesWinningWithoutLosses_Case4()
    {
        const string input = """
                             #######
                             #.E...#
                             #.#..G#
                             #.###.#
                             #E#G#G#
                             #...#G#
                             #######
                             """;

        Sut.Part2(input).Should().Be(6474);
    }

    [Fact]
    public void BattleResultsForElvesWinningWithoutLosses_Case5()
    {
        const string input = """
                             #########
                             #G......#
                             #.E.#...#
                             #..##..G#
                             #...##..#
                             #...#...#
                             #.G...G.#
                             #.....G.#
                             #########
                             """;

        Sut.Part2(input).Should().Be(1140);
    }
}
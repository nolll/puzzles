using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202610Tests : PuzzleTest<Ece202610>
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             ###########
                             #####.#####
                             ###.....###
                             ##.......##
                             ##.>>.<<.##
                             #v...>...v#
                             ##...v...##
                             ##.......##
                             ###.....###
                             #####.#####
                             ###########
                             """;

        Sut.Part1(input).Should().Be(29);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             ###########
                             #####.#####
                             ###.....###
                             ##.......##
                             ##.>>.<<.##
                             #v...>...v#
                             ##...v...##
                             ##.......##
                             ###.....###
                             #####.#####
                             ###########
                             """;

        Sut.Part2(input, 10).Should().Be(53);
    }

    [Fact]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Should().Be(0);
    }
}
namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202425;

public class Aoc202425Tests
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(3);

    private const string Input = """
                                 #####
                                 .####
                                 .####
                                 .####
                                 .#.#.
                                 .#...
                                 .....

                                 #####
                                 ##.##
                                 .#.##
                                 ...##
                                 ...#.
                                 ...#.
                                 .....

                                 .....
                                 #....
                                 #....
                                 #...#
                                 #.#.#
                                 #.###
                                 #####

                                 .....
                                 .....
                                 #.#..
                                 ###..
                                 ###.#
                                 ###.#
                                 #####

                                 .....
                                 .....
                                 .....
                                 #....
                                 #.#..
                                 #.#.#
                                 #####
                                 """;

    private static Aoc202425 Sut => new();
}
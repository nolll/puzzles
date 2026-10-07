using Pzl.Aoc.Puzzles.Aoc2024;

namespace Tests.Aoc.Aoc2024;

public class Aoc202425Tests : PuzzleTest<Aoc202425>
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

}
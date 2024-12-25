using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202425;

public class Aoc202425Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
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

        Sut.Part1(input).Answer.Should().Be("3");
    }

    private static Aoc202425 Sut => new();
}
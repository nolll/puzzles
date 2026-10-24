using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202313Tests : PuzzleTest<Aoc202313>
{
    [Fact]
    public void MirrorsExample1()
    {
        const string input = """
                             #.##..##.
                             ..#.##.#.
                             ##......#
                             ##......#
                             ..#.##.#.
                             ..##..##.
                             #.#.##.#.
                             """;

        Sut.CountReflections(input).Should().Be(5);
    }

    [Fact]
    public void MirrorsMatchLastRow()
    {
        const string input = """
                             ..##..###
                             ##.##.##.
                             #####.##.
                             ..##..###
                             #....#..#
                             #...##..#
                             #...##..#
                             """;

        Sut.CountReflections(input).Should().Be(600);
    }

    [Fact]
    public void MirrorsMatchLastCol()
    {
        const string input = """
                             ..##..#..
                             ##.##.#..
                             ###-#.#..
                             ..##..###
                             #....#.##
                             ##..##.##
                             #...##.##
                             """;
        
        Sut.CountReflections(input).Should().Be(8);
    }
    
    [Fact]
    public void SmudgedMirrors()
    {
        const string input = """
                             #.##..##.
                             ..#.##.#.
                             ##......#
                             ##......#
                             ..#.##.#.
                             ..##..##.
                             #.#.##.#.
                             """;

        Sut.CountSmudgedReflections(input).Should().Be(300);
    }

    [Fact]
    public void SmudgedMirrors2()
    {
        const string input = """
                             #...##..#
                             #....#..#
                             ..##..###
                             #####.##.
                             #####.##.
                             ..##..###
                             #....#..#
                             """;

        Sut.CountSmudgedReflections(input).Should().Be(100);
    }

    [Fact]
    public void Part1()
    {
        const string input = """
                             #.##..##.
                             ..#.##.#.
                             ##......#
                             ##......#
                             ..#.##.#.
                             ..##..##.
                             #.#.##.#.
                             
                             #...##..#
                             #....#..#
                             ..##..###
                             #####.##.
                             #####.##.
                             ..##..###
                             #....#..#
                             """;

        Sut.Part1(input).Should().Be(405);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             #.##..##.
                             ..#.##.#.
                             ##......#
                             ##......#
                             ..#.##.#.
                             ..##..##.
                             #.#.##.#.

                             #...##..#
                             #....#..#
                             ..##..###
                             #####.##.
                             #####.##.
                             ..##..###
                             #....#..#
                             """;

        Sut.Part2(input).Should().Be(400);
    }
}
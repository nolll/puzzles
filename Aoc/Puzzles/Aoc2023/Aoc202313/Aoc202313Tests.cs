namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202313;

public class Aoc202313Tests
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

        var result = Aoc202313.CountReflections(input);

        result.Should().Be(5);
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

        var result = Aoc202313.CountReflections(input);

        result.Should().Be(600);
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

        var result = Aoc202313.CountReflections(input);

        result.Should().Be(8);
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

        var result = Aoc202313.CountSmudgedReflections(input);

        result.Should().Be(300);
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

        var result = Aoc202313.CountSmudgedReflections(input);

        result.Should().Be(100);
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

        var result = new Aoc202313().RunPart1(input);

        result.Answer.Should().Be("405");
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

        var result = new Aoc202313().RunPart2(input);

        result.Answer.Should().Be("400");
    }
}
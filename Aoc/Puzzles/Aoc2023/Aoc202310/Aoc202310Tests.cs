using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202310;

public class Aoc202310Tests
{
    [Fact]
    public void Pipes()
    {
        const string input = """
                             .....
                             .S-7.
                             .|.|.
                             .L-J.
                             .....
                             """;

        var result = Aoc202310.FarthestPoint(input);

        result.Should().Be(4);
    }

    [Fact]
    public void Enlarge()
    {
        const string input = """
                             .....
                             .F-7.
                             .|.|.
                             .L-J.
                             .....
                             """;

        const string expected = """
                             ............
                             ............
                             ............
                             ...F---7....
                             ...|...|....
                             ...|...|....
                             ...|...|....
                             ...L---J....
                             ............
                             ............
                             ............
                             ............
                             """;

        var grid = GridBuilder.BuildCharGrid(input);

        var result = Aoc202310.EnlargeGrid(grid);

        result.Print().Should().Be(expected);
    }

    [Fact]
    public void Enclosed1()
    {
        const string input = """
                             ...........
                             .S-------7.
                             .|F-----7|.
                             .||.....||.
                             .||.....||.
                             .|L-7.F-J|.
                             .|..|.|..|.
                             .L--J.L--J.
                             ...........
                             """;

        var result = Aoc202310.EnclosedTileCount(input);

        result.Should().Be(4);
    }

    [Fact]
    public void Enclosed2()
    {
        const string input = """
                             ..........
                             .S------7.
                             .|F----7|.
                             .||....||.
                             .||....||.
                             .|L-7F-J|.
                             .|..||..|.
                             .L--JL--J.
                             ..........
                             """;

        var result = Aoc202310.EnclosedTileCount(input);

        result.Should().Be(4);
    }
    
    [Fact]
    public void Enclosed3()
    {
        const string input = """
                             .F----7F7F7F7F-7....
                             .|F--7||||||||FJ....
                             .||.FJ||||||||L7....
                             FJL7L7LJLJ||LJ.L-7..
                             L--J.L7...LJS7F-7L7.
                             ....F-J..F7FJ|L7L7L7
                             ....L7.F7||L7|.L7L7|
                             .....|FJLJ|FJ|F7|.LJ
                             ....FJL-7.||.||||...
                             ....L---J.LJ.LJLJ...
                             """;

        var result = Aoc202310.EnclosedTileCount(input);

        result.Should().Be(8);
    }

    [Fact]
    public void Enclosed4()
    {
        const string input = """
                             FF7FSF7F7F7F7F7F---7
                             L|LJ||||||||||||F--J
                             FL-7LJLJ||||||LJL-77
                             F--JF--7||LJLJ7F7FJ-
                             L---JF-JLJ.||-FJLJJ7
                             |F|F-JF---7F7-L7L|7|
                             |FFJF7L7F-JF7|JL---7
                             7-L-JL7||F7|L7F-7F7|
                             L.L7LFJ|||||FJL7||LJ
                             L7JLJL-JLJLJL--JLJ.L
                             """;

        var result = Aoc202310.EnclosedTileCount(input);

        result.Should().Be(10);
    }
}
namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202416;

public class Aoc202416Tests
{
    private const string Input1 = """
                                  ###############
                                  #.......#....E#
                                  #.#.###.#.###.#
                                  #.....#.#...#.#
                                  #.###.#####.#.#
                                  #.#.#.......#.#
                                  #.#.#####.###.#
                                  #...........#.#
                                  ###.#.#####.#.#
                                  #...#.....#.#.#
                                  #.#.#.###.#.#.#
                                  #.....#...#.#.#
                                  #.###.#.#.#.#.#
                                  #S..#.....#...#
                                  ###############
                                  """;
    
    private const string Input2 = """
                                  #################
                                  #...#...#...#..E#
                                  #.#.#.#.#.#.#.#.#
                                  #.#.#.#...#...#.#
                                  #.#.#.#.###.#.#.#
                                  #...#.#.#.....#.#
                                  #.#.#.#.#.#####.#
                                  #.#...#.#.#.....#
                                  #.#.#####.#.###.#
                                  #.#.#.......#...#
                                  #.#.###.#####.###
                                  #.#.#...#.....#.#
                                  #.#.#.#####.###.#
                                  #.#.#.........#.#
                                  #.#.#.#########.#
                                  #S#.............#
                                  #################
                                  """;

    [Fact]
    public void Part1_1()
    {
        Sut.Part1(Input1).Answer.Should().Be("7036");
    }
    
    [Fact]
    public void Part1_2()
    {
        Sut.Part1(Input2).Answer.Should().Be("11048");
    }

    [Fact]
    public void Part2_1()
    {
        Sut.Part2(Input1).Answer.Should().Be("45");
    }
    
    [Fact]
    public void Part2_2()
    {
        Sut.Part2(Input2).Answer.Should().Be("64");
    }

    private static Aoc202416 Sut => new();
}
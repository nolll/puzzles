namespace Pzl.Everybody.Puzzles.Ece2024.Ece202415;

public class Ece202415Tests
{
    private const string Part1Input = """
                                      #####.#####
                                      #.........#
                                      #.######.##
                                      #.........#
                                      ###.#.#####
                                      #H.......H#
                                      ###########
                                      """;

    private const string Part2And3Input = """
                                          ##########.##########
                                          #...................#
                                          #.###.##.###.##.#.#.#
                                          #..A#.#..~~~....#A#.#
                                          #.#...#.~~~~~...#.#.#
                                          #.#.#.#.~~~~~.#.#.#.#
                                          #...#.#.B~~~B.#.#...#
                                          #...#....BBB..#....##
                                          #C............#....C#
                                          #####################
                                          """;

    [Fact]
    public void Part1() => Sut.Part1(Part1Input).Should().Be(26);

    [Fact]
    public void Part2() => Sut.Part2(Part2And3Input).Should().Be(38);

    [Fact]
    public void Part3() => Sut.Part3(Part2And3Input).Should().Be(38);

    private static Ece202415 Sut => new();
}
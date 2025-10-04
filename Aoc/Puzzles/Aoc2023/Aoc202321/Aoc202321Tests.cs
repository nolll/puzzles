namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202321;

public class Aoc202321Tests
{
    private const string Input = """
                                 ...........
                                 .....###.#.
                                 .###.##..#.
                                 ..#.#...#..
                                 ....#.#....
                                 .##..S####.
                                 .##..#...#.
                                 .......##..
                                 .##.#.####.
                                 .##..##.##.
                                 ...........
                                 """;

    [Fact]
    public void CountPositionsAfter1() => 
        Aoc202321.CountPositionsAfter64(Input, 1).Should().Be(2);

    [Fact]
    public void CountPositionsAfter2() => 
        Aoc202321.CountPositionsAfter64(Input, 2).Should().Be(4);

    [Fact]
    public void CountPositionsAfter3() => 
        Aoc202321.CountPositionsAfter64(Input, 3).Should().Be(6);
}
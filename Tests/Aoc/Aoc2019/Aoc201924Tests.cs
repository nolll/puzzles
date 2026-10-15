using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201924Tests : PuzzleTest<Aoc201924>
{
    private const string Input = """
                                 ....#
                                 #..#.
                                 #..##
                                 ..#..
                                 #....
                                 """;

    [Theory]
    [InlineData(0, "....##..#.#..##..#..#....")]
    [InlineData(1, "#..#.####.###.###.##.##..")]
    [InlineData(2, "#####....#....#...#.#.###")]
    [InlineData(3, "#....####....###.##..##.#")]
    [InlineData(4, "####.....###..#.....##...")]
    public void AfterZeroMinutes(int iterations, string expected) => Sut.RunPart1(Input, iterations).Should().Be(expected);
    
    [Fact]
    public void UntilRepeat_BiodiversityRating() => Sut.RunPart1UntilRepeat(Input).Should().Be(2129920);

    [Fact]
    public void Recursive_BugCount() => Sut.RunPart2(Input, 10).Should().Be(99);
}
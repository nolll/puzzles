namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202510;

public class Aoc202510Tests
{
    [Fact]
    public void Part1_1()
    {
        const string input = "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}";

        Sut.Part1(input).Answer.Should().Be("2");
    }
    
    [Fact]
    public void Part1_2()
    {
        const string input = """
                             [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
                             [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
                             [.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
                             """;

        Sut.Part1(input).Answer.Should().Be("7");
    }

    [Fact]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Answer.Should().Be("0");
    }

    private static Aoc202510 Sut => new();
}
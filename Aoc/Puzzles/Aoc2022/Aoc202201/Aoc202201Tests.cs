namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202201;

public class Aoc202201Tests
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(24000);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(45000);

    private const string Input = """
                                 1000
                                 2000
                                 3000

                                 4000

                                 5000
                                 6000

                                 7000
                                 8000
                                 9000

                                 10000
                                 """;

    private Aoc202201 Sut { get; } = new();
}
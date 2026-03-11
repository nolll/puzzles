namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202306;

public class Aoc202306Tests
{
    private const string Input = """
                                 Time:      7  15   30
                                 Distance:  9  40  200
                                 """;

    [Fact]
    public void BoatRace1() => Sut.Part1(Input).Should().Be(288);

    [Fact]
    public void BoatRace2() => Sut.Part2(Input).Should().Be(71503);

    private static Aoc202306 Sut => new();
}
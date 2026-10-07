using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202306Tests : PuzzleTest<Aoc202306>
{
    private const string Input = """
                                 Time:      7  15   30
                                 Distance:  9  40  200
                                 """;

    [Fact]
    public void BoatRace1() => Sut.Part1(Input).Should().Be(288);

    [Fact]
    public void BoatRace2() => Sut.Part2(Input).Should().Be(71503);
}
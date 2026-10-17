using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202012Tests : PuzzleTest<Aoc202012>
{
    private const string Input = """
                                 F10
                                 N3
                                 F7
                                 R90
                                 F11
                                 """;

    [Fact]
    public void SimpleFerryNavigation() => Sut.Part1(Input).Should().Be(25);

    [Fact]
    public void WaypointFerryNavigation() => Sut.Part2(Input).Should().Be(286);
}
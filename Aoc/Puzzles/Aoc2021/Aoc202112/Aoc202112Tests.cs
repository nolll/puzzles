namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202112;

public class Aoc202112Tests
{
    [Fact]
    public void Part1()
    {
        var caveSystem = new CaveSystem(Input.Trim(), false);
        var result = caveSystem.CountPaths();

        result.Should().Be(10);
    }

    [Fact]
    public void Part2()
    {
        var caveSystem = new CaveSystem(Input.Trim(), true);
        var result = caveSystem.CountPaths();

        result.Should().Be(36);
    }

    private const string Input = """
                                 start-A
                                 start-b
                                 A-c
                                 A-b
                                 b-d
                                 A-end
                                 b-end
                                 """;
}
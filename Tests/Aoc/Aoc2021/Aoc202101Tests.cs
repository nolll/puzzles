using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202101Tests : PuzzleTest<Aoc202101>
{
    [Fact]
    public void Part1()
    {
        var validator = new Aoc202101.DepthMeasurement();
        var result = validator.GetNumberOfIncreasingMeasurements(Input.Trim(), false);

        result.Should().Be(7);
    }

    [Fact]
    public void Part2()
    {
        var validator = new Aoc202101.DepthMeasurement();
        var result = validator.GetNumberOfIncreasingMeasurements(Input.Trim(), true);

        result.Should().Be(5);
    }

    private const string Input = """
                                 199
                                 200
                                 208
                                 210
                                 200
                                 207
                                 240
                                 269
                                 260
                                 263
                                 """;
}
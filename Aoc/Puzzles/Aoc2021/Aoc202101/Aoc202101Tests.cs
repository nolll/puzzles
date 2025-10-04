namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202101;

public class Aoc202101Tests
{
    [Fact]
    public void Part1()
    {
        var validator = new DepthMeasurement();
        var result = validator.GetNumberOfIncreasingMeasurements(Input.Trim(), false);

        result.Should().Be(7);
    }

    [Fact]
    public void Part2()
    {
        var validator = new DepthMeasurement();
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
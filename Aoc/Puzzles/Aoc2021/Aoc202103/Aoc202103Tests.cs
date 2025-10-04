namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202103;

public class Aoc202103Tests
{
    [Fact]
    public void Part1()
    {
        var diagnostics = new BinaryDiagnostics();
        var result = diagnostics.GetFuelConsumption(Input.Trim());

        result.Should().Be(198);
    }

    [Fact]
    public void Part2()
    {
        var diagnostics = new BinaryDiagnostics();
        var result = diagnostics.GetLifeSupportRating(Input.Trim());

        result.Should().Be(230);
    }

    private const string Input = """
                                 00100
                                 11110
                                 10110
                                 10111
                                 10101
                                 01111
                                 00111
                                 11100
                                 10000
                                 11001
                                 00010
                                 01010
                                 """;
}
namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201722;

public class Aoc201722Tests
{
    private const string Input = """
                                 ..#
                                 #..
                                 ...
                                 """;

    [Theory]
    [InlineData(7, 5)]
    [InlineData(70, 41)]
    [InlineData(10000, 5587)]
    public void InfectionCountIsCorrectForPart1(int iterations, int expected)
    {
        var infection = new VirusInfection(Input);
        var infectionCount = infection.RunPart1(iterations);

        infectionCount.Should().Be(expected);
    }

    [Theory]
    [InlineData(100, 26)]
    [InlineData(10_000_000, 2_511_944)]
    public void InfectionCountIsCorrectForPart2(int iterations, int expected)
    {
        var infection = new VirusInfection(Input);
        var infectionCount = infection.RunPart2(iterations);

        infectionCount.Should().Be(expected);
    }
}
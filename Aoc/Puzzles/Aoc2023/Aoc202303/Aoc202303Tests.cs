namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202303;

public class Aoc202303Tests
{
    private const string Input = """
                                 467..114..
                                 ...*......
                                 ..35..633.
                                 ......#...
                                 617*......
                                 .....+.58.
                                 ..592.....
                                 ......755.
                                 ...$.*....
                                 .664.598..
                                 """;

    [Fact]
    public void EngineParts()
    {
        var result = Aoc202303.Run(Input);

        result.EngineParts.Should().Be(4361);
    }

    [Fact]
    public void GearRatios()
    {
        var result = Aoc202303.Run(Input);

        result.GearRatios.Should().Be(467835);
    }
}
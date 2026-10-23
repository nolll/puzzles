using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202303Tests : PuzzleTest<Aoc202303>
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
    public void EngineParts() => Sut.Solve(Input).EngineParts.Should().Be(4361);

    [Fact]
    public void GearRatios() => Sut.Solve(Input).GearRatios.Should().Be(467835);
}
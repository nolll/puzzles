namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202107;

public class Aoc202107Tests
{
    [Fact]
    public void Part1()
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetFuel1(Input, false);

        result.Should().Be(37);
    }

    [Fact]
    public void Part2()
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetFuel1(Input, true);

        result.Should().Be(168);
    }

    [Theory]
    [InlineData(16, 5, 11)]
    [InlineData(1, 5, 4)]
    [InlineData(2, 2, 0)]
    public void CostPart1(int a, int b, int expected)
    {
        var result = CrabSubmarines.GetCost(a, b);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(16, 5, 66)]
    [InlineData(1, 5, 10)]
    [InlineData(0, 5, 15)]
    [InlineData(4, 5, 1)]
    [InlineData(7, 5, 3)]
    [InlineData(2, 5, 6)]
    [InlineData(14, 5, 45)]
    [InlineData(5, 16, 66)]
    [InlineData(5, 5, 0)]
    public void CostPart2(int a, int b, int expected)
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetCrabEnginerringCost(a, b);

        result.Should().Be(expected);
    }

    private const string Input = "16,1,2,0,4,2,7,1,2,14";
}
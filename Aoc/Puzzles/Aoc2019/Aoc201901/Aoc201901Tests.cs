namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201901;

public class Aoc201901Tests
{
    [Theory]
    [InlineData(14, 2)]
    [InlineData(1969, 654)]
    [InlineData(100756, 33583)]
    public void RequiredFuelIsCorrect(int mass, int expectedFuel)
    {
        var module = new Module(mass);
        module.MassFuel.Should().Be(expectedFuel);
    }

    [Theory]
    [InlineData(14, 2)]
    [InlineData(1969, 966)]
    [InlineData(100756, 50346)]
    public void TotalFuelIsCorrect(int mass, int expectedFuel)
    {
        var module = new Module(mass);
        module.TotalFuel.Should().Be(expectedFuel);
    }
}
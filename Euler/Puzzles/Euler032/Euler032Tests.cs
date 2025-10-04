namespace Pzl.Euler.Puzzles.Euler032;

public class Euler032Tests
{
    [Fact]
    public void IsPandigital()
    {
        var puzzle = new Euler032();
        var result = Euler032.IsPandigital(39, 186);

        result.Should().BeTrue();
    }

    [Fact]
    public void IsNotPandigital()
    {
        var puzzle = new Euler032();
        var result = Euler032.IsPandigital(1, 2);

        result.Should().BeFalse();
    }
}
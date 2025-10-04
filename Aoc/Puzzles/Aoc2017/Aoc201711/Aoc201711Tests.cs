namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201711;

public class Aoc201711Tests
{
    [Theory]
    [InlineData("ne,ne,ne", 3)]
    [InlineData("ne,ne,sw,sw", 0)]
    [InlineData("ne,ne,s,s", 2)]
    [InlineData("se,sw,se,sw,sw", 3)]
    public void DistanceIsCorrect(string input, int expected)
    {
        var navigator = new HexGridNavigator(input);

        navigator.EndDistance.Should().Be(expected);
    }
}
using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler042Tests : PuzzleTest<Euler042>
{
    [Fact]
    public void GetWordValue()
    {
        var result = Euler042.GetWordValue("SKY");

        result.Should().Be(55);
    }
}
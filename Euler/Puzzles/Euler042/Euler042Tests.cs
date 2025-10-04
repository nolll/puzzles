namespace Pzl.Euler.Puzzles.Euler042;

public class Euler042Tests
{
    [Fact]
    public void GetWordValue()
    {
        var result = Euler042.GetWordValue("SKY");

        result.Should().Be(55);
    }
}
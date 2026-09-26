namespace Tests.Euler.Puzzles.Euler042;

public class Euler042Tests
{
    [Fact]
    public void GetWordValue()
    {
        var result = Pzl.Euler.Puzzles.Euler042.Euler042.GetWordValue("SKY");

        result.Should().Be(55);
    }
}
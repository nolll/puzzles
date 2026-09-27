namespace Tests.Aquaq;

public class Aquaq06Tests
{
    [Fact]
    public void CountOccurrencesOfOne()
    {
        var result = Pzl.Aquaq.Puzzles.Aquaq06.Aquaq06.FindOneCount(3);

        result.Should().Be(9);
    }
}
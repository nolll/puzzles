namespace Pzl.Euler.Puzzles.Euler013;

public class Euler013Tests
{
    [Fact]
    public void Test()
    {
        const string numbers = """
                               10000000000000000000000000000000000000000000000000
                               20000000000000000000000000000000000000000000000000
                               30000000000000000000000000000000000000000000000000
                               """;

        Sut.Run(numbers).Answer.Should().Be("6000000000");
    }

    private static Euler013 Sut => new();
}
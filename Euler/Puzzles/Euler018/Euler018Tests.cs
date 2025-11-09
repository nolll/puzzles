namespace Pzl.Euler.Puzzles.Euler018;

public class Euler018Tests
{
    [Fact]
    public void Test()
    {
        const string input = """
                                3
                                7 4
                                2 4 6
                                8 5 9 3
                                """;
        
        Sut.Run(input).Answer.Should().Be("23");
    }

    private static Euler018 Sut => new();
}
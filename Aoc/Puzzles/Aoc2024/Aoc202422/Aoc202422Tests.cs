namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202422;

public class Aoc202422Tests
{
    [Theory]
    [InlineData(1, 15887950)]
    [InlineData(2, 16495136)]
    [InlineData(3, 527345)]
    [InlineData(4, 704524)]
    [InlineData(5, 1553684)]
    [InlineData(6, 12683156)]
    [InlineData(7, 11100544)]
    [InlineData(8, 12249484)]
    [InlineData(9, 7753432)]
    [InlineData(10, 5908254)]
    public void Generate(int iterations, long expected) => 
        Aoc202422.Generate(123, iterations).Last().Should().Be(expected);

    [Fact]
    public void Part1()
    {
        const string input = """
                             1
                             10
                             100
                             2024
                             """;

        Sut.Part1(input).Answer.Should().Be("37327623");
    }
    
    [Fact]
    public void Part2()
    {
        const string input = """
                             1
                             2
                             3
                             2024
                             """;

        Sut.Part2(input).Answer.Should().Be("23");
    }

    private static Aoc202422 Sut => new();
}
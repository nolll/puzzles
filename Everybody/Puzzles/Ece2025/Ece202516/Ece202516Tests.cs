namespace Pzl.Everybody.Puzzles.Ece2025.Ece202516;

public class Ece202516Tests
{
    [Fact]
    public void Part1()
    {
        const string input = "1,2,3,5,9";

        Sut.Part1(input).Answer.Should().Be("193");
    }

    [Fact]
    public void Part2()
    {
        const string input = "1,2,2,2,2,3,1,2,3,3,1,3,1,2,3,2,1,4,1,3,2,2,1,3,2,2";

        Sut.Part2(input).Answer.Should().Be("270");
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(10, 5)]
    [InlineData(100, 47)]
    [InlineData(1000, 467)]
    [InlineData(10000, 4664)]
    [InlineData(100000, 46633)]
    [InlineData(1000000, 466322)]
    [InlineData(10000000, 4663213)]
    [InlineData(100000000, 46632125)]
    [InlineData(1000000000, 466321244)]
    [InlineData(10000000000, 4663212435)]
    [InlineData(100000000000, 46632124353)]
    [InlineData(1000000000000, 466321243524)]
    [InlineData(10000000000000, 4663212435233)]
    [InlineData(100000000000000, 46632124352332)]
    [InlineData(202520252025000, 94439495762954)]
    public void Part3(long availableBlocks, long expected)
    {
        const string input = "1,2,2,2,2,3,1,2,3,3,1,3,1,2,3,2,1,4,1,3,2,2,1,3,2,2";

        Sut.Part3(input, availableBlocks).Should().Be(expected);
    }

    private static Ece202516 Sut => new();
}
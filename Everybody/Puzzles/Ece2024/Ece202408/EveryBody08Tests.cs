namespace Pzl.Everybody.Puzzles.Ece2024.Ece202408;

public class EveryBody08Tests
{
    [Fact]
    public void Part1()
    {
        var result = Sut.Part1("13");
        result.Answer.Should().Be("21");
    }
    
    [Fact]
    public void Part2()
    {
        var result = Sut.SolvePart2("3", 50, 5);
        result.Should().Be(27);
    }
    
    [Fact]
    public void Part3()
    {
        var result = Sut.SolvePart3("2", 160, 5);
        result.Should().Be(2);
    }
    
    private static Ece202408 Sut => new();
}
namespace Pzl.Everybody.Puzzles.Ece2024.Ece202403;

public class Ece202403Tests
{
    private const string Input = """
                                 ..........
                                 ..###.##..
                                 ...####...
                                 ..######..
                                 ..######..
                                 ...####...
                                 ..........
                                 """;

    [Fact]
    public void Part1And2()
    {
        var result = Sut.RunPart1(Input);
        result.Answer.Should().Be("35");
    }
    
    [Fact]
    public void Part3()
    {
        var result = Sut.RunPart3(Input);
        result.Answer.Should().Be("29");
    }

    private static Ece202403 Sut => new();
}
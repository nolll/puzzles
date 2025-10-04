namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202324;

public class Aoc202324Tests
{
    private const string Input = """
                                 19, 13, 30 @ -2,  1, -2
                                 18, 19, 22 @ -1, -1, -2
                                 20, 25, 34 @ -2, -2, -4
                                 12, 31, 28 @ -1, -2, -1
                                 20, 19, 15 @  1, -5, -3
                                 """;

    [Fact]
    public void CountIntersecting()
    {
        var result = Aoc202324.CountIntersectingWithin(Input, 7, 27);

        result.Should().Be(2);
    }
    
    [Fact]
    public void Part2()
    {
        var result = Sut.RunPart2(Input);

        result.Answer.Should().Be("47");
    }

    private static Aoc202324 Sut => new();
}
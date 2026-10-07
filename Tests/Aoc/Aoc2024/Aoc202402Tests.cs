using Pzl.Aoc.Puzzles.Aoc2024;

namespace Tests.Aoc.Aoc2024;

public class Aoc202402Tests : PuzzleTest<Aoc202402>
{
    private const string Input = """
                                 7 6 4 2 1
                                 1 2 7 8 9
                                 9 7 6 2 1
                                 1 3 2 4 5
                                 8 6 4 4 1
                                 1 3 6 7 9
                                 """;

    [Fact]
    public void Part1()
    {
        var result = Sut.Part1(Input);
        result.Should().Be(2);
    }
    
    [Fact]
    public void Part2()
    {
        var result = Sut.Part2(Input);
        result.Should().Be(4);
    }

}
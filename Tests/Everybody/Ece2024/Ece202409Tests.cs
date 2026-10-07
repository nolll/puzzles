using Pzl.Everybody.Puzzles.Ece2024;

namespace Tests.Everybody.Ece2024;

public class Ece202409Tests : PuzzleTest<Ece202409>
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             2
                             4
                             7
                             16
                             """;

        Sut.Part1(input).Should().Be(10);
    }
    
    [Fact]
    public void Part2()
    {
        const string input = """
                             33
                             41
                             55
                             99
                             """;

        Sut.Part2(input).Should().Be(10);
    }
    
    [Fact]
    public void Part3()
    {
        const string input = """
                             156488
                             352486
                             546212
                             """;

        Sut.Part3(input).Should().Be(10449);
    }
    
}
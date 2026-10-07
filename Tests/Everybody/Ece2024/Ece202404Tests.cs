using Pzl.Everybody.Puzzles.Ece2024;

namespace Tests.Everybody.Ece2024;

public class Ece202404Tests : PuzzleTest<Ece202404>
{
    [Fact]
    public void Part1And2()
    {
        const string input = """
                             3
                             4
                             7
                             8
                             """;

        Sut.Part1(input).Should().Be(10);
    }
    
    [Fact]
    public void Part3()
    {
        const string input = """
                             2
                             4
                             5
                             6
                             8
                             """;

        Sut.Part3(input).Should().Be(8);
    }

}
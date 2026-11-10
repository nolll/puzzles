using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202611Tests : PuzzleTest<Ece202611>
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             portals: 10
                             
                             5 10
                             2 7
                             """;

        Sut.Part1(input).Should().Be(60);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             portals: 10
                             
                             5 10
                             2 7
                             """;

        Sut.Part2(input).Should().Be(6);
    }

    [Fact]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Should().Be(0);
    }
}
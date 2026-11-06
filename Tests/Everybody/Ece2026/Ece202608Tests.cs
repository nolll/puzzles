using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202608Tests : PuzzleTest<Ece202608>
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             ....1.9.6.1.7....
                             ...9.2.3.3.8.1...
                             ..7.8.3.5.1.4.3..
                             .4.6.7.4.1.1.8.9.
                             4.5.3.6.5.8.9.4.9
                             .9.5.1.5.6.2.8.9.
                             ..7.7.6.4.6.2.4..
                             ...9.3.8.3.8.4...
                             ....1.6.6.2.8....
                             """;

        Sut.Part1(input).Should().Be(32);
    }

    [Fact]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Should().Be(0);
    }

    [Fact]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Should().Be(0);
    }
}
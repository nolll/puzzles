using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202609Tests : PuzzleTest<Ece202609>
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             id=1, growth=3, limit=10
                             id=2, growth=5, limit=20
                             id=3, growth=7, limit=30
                             """;

        Sut.Part1(input).Should().Be(27);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             id=1, growth=3, limit=10
                             id=2, growth=5, limit=20
                             id=3, growth=7, limit=30
                             """;

        Sut.Part2(input).Should().Be(42);
    }
}
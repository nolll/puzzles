using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler018Tests : PuzzleTest<Euler018>
{
    private const string Input = """
                                 3
                                 7 4
                                 2 4 6
                                 8 5 9 3
                                 """;

    [Fact]
    public void Test() => Sut.Solve(Input).Should().Be(23);
}
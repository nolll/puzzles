using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler013Tests : PuzzleTest<Euler013>
{
    private const string Input = """
                                 10000000000000000000000000000000000000000000000000
                                 20000000000000000000000000000000000000000000000000
                                 30000000000000000000000000000000000000000000000000
                                 """;

    [Fact]
    public void Test() => Sut.Solve(Input).Should().Be("6000000000");
}
using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler013Tests : PuzzleTest<Euler013>
{
    [Fact]
    public void Test()
    {
        const string numbers = """
                               10000000000000000000000000000000000000000000000000
                               20000000000000000000000000000000000000000000000000
                               30000000000000000000000000000000000000000000000000
                               """;

        Sut.Solve(numbers).Should().Be("6000000000");
    }

}
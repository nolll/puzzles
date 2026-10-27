using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler011Tests : PuzzleTest<Euler011>
{
    private const string Input = """
                                 01 01 01 01 01
                                 01 02 02 02 01
                                 01 02 02 02 01
                                 01 02 02 03 01
                                 01 01 01 01 04
                                 """;

    [Fact]
    public void Test() => Sut.Solve(Input).Should().Be(48);
}
using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq21Tests : PuzzleTest<Aquaq21>
{
    private const string Input = """
                                 3 4 5 1 3
                                 9 3 4 0 9
                                 4 5 4 4 7
                                 3 7 9 8 2
                                 """;

    [Fact]
    public void CollectDust()
    {
        var result = Aquaq21.Solve(Input, 3);

        result.Should().Be(65);
    }
}
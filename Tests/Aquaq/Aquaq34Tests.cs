using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq34Tests : PuzzleTest<Aquaq34>
{
    private const string Input = """
                                 station,r1,r2,r3
                                 a,00:01,,00:02
                                 b,00:16,,00:17
                                 c,,00:21,
                                 d,00:46,00:51,00:47
                                 """;

    [Fact]
    public void TrainRoutes() => new Aquaq34().Solve(Input).Should().Be(64);
}
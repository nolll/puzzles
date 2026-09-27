using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq12Tests
{
    private const string Input = """
                                 1 2
                                 0 3
                                 1 1
                                 0 1
                                 1 5
                                 """;

    [Fact]
    public void RideTheLift() => Sut.Solve(Input).Should().Be(7);

    private static Aquaq12 Sut => new();
}
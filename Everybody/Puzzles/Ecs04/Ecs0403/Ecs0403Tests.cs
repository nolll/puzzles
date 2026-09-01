namespace Pzl.Everybody.Puzzles.Ecs04.Ecs0403;

public class Ecs0403Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             width=30
                             height=10
                             horizontal-offsets=10011
                             vertical-offsets=11011
                             """;

        Sut.Part1(input).Should().Be(27);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             width=30
                             height=10
                             horizontal-offsets=10011
                             vertical-offsets=11011
                             """;

        Sut.Part2(input).Should().Be(15);
    }

    private static Ecs0403 Sut => new();
}
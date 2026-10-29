using Pzl.Everybody.Puzzles.Ecs04;

namespace Tests.Everybody.Ecs04;

public class Ecs0403Tests : PuzzleTest<Ecs0403>
{
    private const string Input = """
                                 width=30
                                 height=10
                                 horizontal-offsets=10011
                                 vertical-offsets=11011
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(27);

    [Fact]
    public void Part2_1() => Sut.Part2(Input).Should().Be(15);

    [Fact]
    public void Part2_2()
    {
        const string input = """
                             width=40
                             height=12
                             horizontal-offsets=11100
                             vertical-offsets=001101
                             """;

        Sut.Part2(input).Should().Be(7);
    }

}
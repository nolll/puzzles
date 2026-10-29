using Pzl.Everybody.Puzzles.Ece2025;

namespace Tests.Everybody.Ece2025;

public class Ece202504Tests : PuzzleTest<Ece202504>
{
    private const string InputPart1And2 = """
                                          102
                                          75
                                          50
                                          35
                                          13
                                          """;

    [Fact]
    public void Part1() => Sut.Part1(InputPart1And2).Should().Be(15888);

    [Fact]
    public void Part2() => Sut.Part2(InputPart1And2).Should().Be(1274509803922);

    [Fact]
    public void Part3()
    {
        const string input = """
                             5
                             7|21
                             18|36
                             27|27
                             10|50
                             10|50
                             11
                             """;

        Sut.Part3(input).Should().Be(6818);
    }
}
using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201803Tests : PuzzleTest<Aoc201803>
{
    private const string Input1 = """
                                  #1 @ 1,1: 1x1
                                  #2 @ 3,3: 1x1
                                  #3 @ 5,5: 1x1
                                  """;

    private const string Input2 = """
                                  #1 @ 1,3: 4x4
                                  #2 @ 3,1: 4x4
                                  #3 @ 5,5: 2x2
                                  """;

    [Fact]
    public void NoOverlap() => Sut.Part1(Input1).Should().Be(0);

    [Fact]
    public void Overlap() => Sut.Part1(Input2).Should().Be(4);

    [Fact]
    public void IdWithNoOverlap() => Sut.Part2(Input2).Should().Be(3);
}
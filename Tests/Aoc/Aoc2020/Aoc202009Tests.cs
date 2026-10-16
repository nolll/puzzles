using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202009Tests : PuzzleTest<Aoc202009>
{
    private const string Input = """
                                 35
                                 20
                                 15
                                 25
                                 47
                                 40
                                 62
                                 55
                                 65
                                 95
                                 102
                                 117
                                 150
                                 182
                                 127
                                 219
                                 299
                                 277
                                 309
                                 576
                                 """;

    [Fact]
    public void FirstInvalidNumber() => Sut.Part1(Input, 5).Should().Be(127);

    [Fact]
    public void FirstWeakness() => Sut.Part2(Input, 5).Should().Be(62);
}
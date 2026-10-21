using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202218Tests : PuzzleTest<Aoc202218>
{
    [Fact]
    public void Part1Small() => Sut.Part1(SmallInput).Should().Be(10);

    [Fact]
    public void Part1Large() => Sut.Part1(LargeInput).Should().Be(64);

    [Fact]
    public void Part2() => Sut.Part2(LargeInput).Should().Be(58);

    private const string SmallInput = """
                                      1,1,1
                                      2,1,1
                                      """;

    private const string LargeInput = """
                                      2,2,2
                                      1,2,2
                                      3,2,2
                                      2,1,2
                                      2,3,2
                                      2,2,1
                                      2,2,3
                                      2,2,4
                                      2,2,6
                                      1,2,5
                                      3,2,5
                                      2,1,5
                                      2,3,5
                                      """;
}
using Pzl.Aoc.Puzzles.Aoc2025;

namespace Tests.Aoc.Aoc2025;

public class Aoc202504Tests : PuzzleTest<Aoc202504>
{
    private const string Input = """
                                 ..@@.@@@@.
                                 @@@.@.@.@@
                                 @@@@@.@.@@
                                 @.@@@@..@.
                                 @@.@@@@.@@
                                 .@@@@@@@.@
                                 .@.@.@.@@@
                                 @.@@@.@@@@
                                 .@@@@@@@@.
                                 @.@.@@@.@.
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(13);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(43);

}
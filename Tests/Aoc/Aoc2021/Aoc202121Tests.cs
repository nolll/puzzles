using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202121Tests : PuzzleTest<Aoc202121>
{
    private const string Input = """
                                 Player 1 starting position: 4
                                 Player 2 starting position: 8
                                 """;
    
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(739785);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(444356092776315);
}

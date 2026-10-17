using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202022Tests : PuzzleTest<Aoc202022>
{
    [Fact]
    public void NormalGame_WinningScoreIs306() => Sut.Part1(Input).Should().Be(306);

    [Fact]
    public void RecursiveGame_WinningScoreIs306() => Sut.Part2(Input).Should().Be(291);

    private const string Input = """
                                 Player 1:
                                 9
                                 2
                                 6
                                 3
                                 1

                                 Player 2:
                                 5
                                 8
                                 4
                                 7
                                 10
                                 """;
}
using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202011Tests : PuzzleTest<Aoc202011>
{
    private const string Input = """
                                 L.LL.LL.LL
                                 LLLLLLL.LL
                                 L.L.L..L..
                                 LLLL.LL.LL
                                 L.LL.LL.LL
                                 L.LLLLL.LL
                                 ..L.L.....
                                 LLLLLLLLLL
                                 L.LLLLLL.L
                                 L.LLLLL.LL
                                 """;

    [Fact]
    public void NumberOfOccupiedSeatsIsCorrect_FirstAlgorithm() => Sut.Part1(Input).Should().Be(37);

    [Fact]
    public void NumberOfOccupiedSeatsIsCorrect_SecondAlgorithm() => Sut.Part2(Input).Should().Be(26);
}
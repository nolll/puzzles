using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202023Tests : PuzzleTest<Aoc202023>
{
    private const string Input = "389125467";

    [Fact]
    public void ResultAfter10MovesIsCorrect() => Sut.Part1(Input, 10).Should().Be("92658374");

    [Fact]
    public void ExtendedResultAfter10MillionMovesIsCorrect() => Sut.Part2(Input).Should().Be(149_245_887_792);
}
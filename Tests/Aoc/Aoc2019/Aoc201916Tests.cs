using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201916Tests : PuzzleTest<Aoc201916>
{
    [Theory]
    [InlineData(1, "48226158")]
    [InlineData(2, "34040438")]
    [InlineData(3, "03415518")]
    [InlineData(4, "01029498")]
    public void SimpleAfterOnePhase(int phaseCount, string expected) => Sut.SolvePart1("12345678", phaseCount).Should().Be(expected);

    [Theory]
    [InlineData("80871224585914546619083218645595", "24176176")]
    [InlineData("19617804207202209144916044189917", "73745418")]
    [InlineData("69317163492948606335995924319873", "52432133")]
    public void FirstEightDigitsAfter100Phases(string input, string expected) => Sut.SolvePart1(input, 100).Should().Be(expected);

    [Theory]
    [InlineData("03036732577212944063491565474664", "84462026")]
    [InlineData("02935109699940807407585447034323", "78725270")]
    [InlineData("03081770884921959731165446850517", "53553731")]
    public void MessageAfter100RealPhases(string input, string expected) => Sut.SolvePart2(input, 100).Should().Be(expected);
}
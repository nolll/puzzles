using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201717Tests : PuzzleTest<Aoc201717>
{
    [Fact]
    public void NextValueIsCorrect() => Sut.RunPart1(3, 2017).Should().Be(638);

    [Fact]
    public void SecondValueIsCorrect() => Sut.RunPart2(3, 2017).Should().Be(1226);
}
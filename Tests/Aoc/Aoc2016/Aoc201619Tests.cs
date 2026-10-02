using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201619Tests : PuzzleTest<Aoc201619>
{
    private const string Input = "5";

    [Fact]
    public void StealFromNextElf_ThirdElfGetsAllPresents() => Sut.StealFromNextElf(Input).Should().Be(3);

    [Fact]
    public void StealFromAcrossTheCircle_SecondElfGetsAllPresents() => Sut.StealFromElfAcrossCircle(Input).Should().Be(2);
}
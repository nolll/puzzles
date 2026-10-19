using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202117Tests : PuzzleTest<Aoc202117>
{
    private static Aoc202117.TrickshotTarget Target => new(20, 30, -10, -5);
    
    [Fact]
    public void Part1() => Sut.Shoot(Target).MaxHeight.Should().Be(45);

    [Fact]
    public void SingleMaxHeight() => Sut.GetMaxHeight(Target, 6, 9).Should().Be(45);

    [Fact]
    public void SingleVelocityCount() => Sut.Shoot(Target).HitCount.Should().Be(112);
}
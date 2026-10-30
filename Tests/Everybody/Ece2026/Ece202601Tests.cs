using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202601Tests : PuzzleTest<Ece202601>
{
    [Fact]
    public void Part1() => Sut.Part1("3,11,12,16,24,25").Should().Be(11);

    [Fact]
    public void Part2() => Sut.Part2("3,11,12,16,24,25").Should().Be(9);

    [Fact]
    public void Part3() => Sut.Part3("3,11,12,16,24,25").Should().Be(61);
}
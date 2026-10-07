using Pzl.Everybody.Puzzles.Ece2025;

namespace Tests.Everybody.Ece2025;

public class Ece202506Tests : PuzzleTest<Ece202506>
{
    [Fact]
    public void Part1() => Sut.Part1("ABabACacBCbca").Should().Be(5);

    [Fact]
    public void Part2() => Sut.Part2("ABabACacBCbca").Should().Be(11);

    [Fact]
    public void Part3() => Sut.Part3("AABCBABCABCabcabcABCCBAACBCa").Should().Be(3442321);

}
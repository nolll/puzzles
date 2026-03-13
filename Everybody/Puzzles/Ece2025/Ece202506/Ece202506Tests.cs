namespace Pzl.Everybody.Puzzles.Ece2025.Ece202506;

public class Ece202506Tests
{
    [Fact]
    public void Part1() => Sut.Part1("ABabACacBCbca").Should().Be(5);

    [Fact]
    public void Part2() => Sut.Part2("ABabACacBCbca").Should().Be(11);

    [Fact]
    public void Part3() => Sut.Part3("AABCBABCABCabcabcABCCBAACBCa").Should().Be(3442321);

    private static Ece202506 Sut => new();
}
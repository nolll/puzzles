namespace Pzl.Everybody.Puzzles.Ece2024.Ece202401;

public class Ece202401Tests
{
    [Fact]
    public void OneCreature() => Sut.Part1("ABBAC").Should().Be(5);

    [Fact]
    public void TwoCreatures() => Sut.Part2("AxBCDDCAxD").Should().Be(28);

    [Fact]
    public void ThreeCreatures() => Sut.Part3("xBxAAABCDxCC").Should().Be(30);

    private static Ece202401 Sut => new();
}
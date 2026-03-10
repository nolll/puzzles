namespace Pzl.Aquaq.Puzzles.Aquaq01;

public class Aquaq01Test
{
    [Fact]
    public void HexString() => Sut.Solve("kdb4life").Should().Be("0d40fe");

    private static Aquaq01 Sut => new();
}
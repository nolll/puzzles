using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq01Test
{
    [Fact]
    public void HexString() => Sut.Solve("kdb4life").Should().Be("0d40fe");

}
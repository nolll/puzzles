namespace Pzl.Euler.Puzzles.Euler001;

public class Euler001Tests
{
    [Fact]
    public void Test() => new Euler001().Run(10).Should().Be(23);

    private static Euler001 Sut => new();
}
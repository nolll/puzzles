namespace Pzl.Aquaq.Puzzles.Aquaq31;

public class Aquaq31Tests
{
    [Fact]
    public void Rotate() => new Aquaq31().Solve("U'LBRU").Should().Be(960);
}
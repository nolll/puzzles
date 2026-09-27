namespace Tests.Aquaq;

public class Aquaq31Tests
{
    [Fact]
    public void Rotate() => new Pzl.Aquaq.Puzzles.Aquaq31.Aquaq31().Solve("U'LBRU").Should().Be(960);
}
using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler042Tests : PuzzleTest<Euler042>
{
    [Fact]
    public void GetWordValue() => Sut.GetWordValue("SKY").Should().Be(55);
}
using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq06Tests : PuzzleTest<Aquaq06>
{
    [Fact]
    public void CountOccurrencesOfOne() => Sut.FindOneCount(3).Should().Be(9);
}
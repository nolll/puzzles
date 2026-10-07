using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq06Tests : PuzzleTest<Aquaq06>
{
    [Fact]
    public void CountOccurrencesOfOne()
    {
        var result = Aquaq06.FindOneCount(3);

        result.Should().Be(9);
    }
}
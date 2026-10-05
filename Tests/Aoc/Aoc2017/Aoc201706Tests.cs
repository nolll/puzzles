using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201706Tests : PuzzleTest<Aoc201706>
{
    [Fact]
    public void BothParts()
    {
        var (steps, loopSize) = Sut.Run("0,2,7,0");

        steps.Should().Be(5);
        loopSize.Should().Be(4);
    }
}
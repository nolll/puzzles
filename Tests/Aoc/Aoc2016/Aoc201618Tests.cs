using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201618Tests : PuzzleTest<Aoc201618>
{
    [Fact]
    public void SafeCountIsCorrect() => Sut.CountSafeTiles(".^^.^.^^^^", 10).Should().Be(38);
}
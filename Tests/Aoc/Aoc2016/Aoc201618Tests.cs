using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201618Tests
{
    [Fact]
    public void SafeCountIsCorrect()
    {
        const string input = ".^^.^.^^^^";

        var detector = new Aoc201618.FloorTrapDetector(input);
        var safeCount = detector.CountSafeTiles(10);

        safeCount.Should().Be(38);
    }
}
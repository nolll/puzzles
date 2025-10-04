namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201618;

public class Aoc201618Tests
{
    [Fact]
    public void SafeCountIsCorrect()
    {
        const string input = ".^^.^.^^^^";

        var detector = new FloorTrapDetector(input);
        var safeCount = detector.CountSafeTiles(10);

        safeCount.Should().Be(38);
    }
}
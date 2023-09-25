using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2016.Aoc201618;

public class Aoc201618Tests
{
    [Test]
    public void SafeCountIsCorrect()
    {
        const string input = ".^^.^.^^^^";

        var detector = new FloorTrapDetector(input);
        var safeCount = detector.CountSafeTiles(10);

        Assert.That(safeCount, Is.EqualTo(38));
    }
}
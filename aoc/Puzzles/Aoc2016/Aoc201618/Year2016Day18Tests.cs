using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2016.Day18;

public class Year2016Day18Tests
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
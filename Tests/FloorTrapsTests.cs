using ConsoleApp.Puzzles.Year2016.Day18;
using NUnit.Framework;

namespace Tests
{
    public class FloorTrapsTests
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
}
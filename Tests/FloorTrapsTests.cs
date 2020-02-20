using Core.FloorTraps;
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
            detector.FindTraps(10);

            Assert.That(detector.SafeCount, Is.EqualTo(38));
        }
    }
}
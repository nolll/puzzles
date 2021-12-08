using NUnit.Framework;

namespace App.Puzzles.Year2015.Day25
{
    public class Year2015Day25Tests
    {
        [Test]
        public void FindsCode3_3()
        {
            const int targetX = 3;
            const int targetY = 3;

            var codeFinder = new WeatherMachineCodeFinder();
            var code = codeFinder.FindCodeAt(targetX, targetY);

            Assert.That(code, Is.EqualTo(1601130));
        }

        [Test]
        public void FindsCode6_4()
        {
            const int targetX = 6;
            const int targetY = 4;

            var codeFinder = new WeatherMachineCodeFinder();
            var code = codeFinder.FindCodeAt(targetX, targetY);

            Assert.That(code, Is.EqualTo(31527494));
        }
    }
}
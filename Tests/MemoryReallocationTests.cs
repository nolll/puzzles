using ConsoleApp.Puzzles.Year2017.Puzzles.Day06;
using NUnit.Framework;

namespace Tests
{
    public class MemoryReallocationTests
    {
        [Test]
        public void StepsUntilRepeat()
        {
            const string input = "0,2,7,0";
            var reallocator = new MemoryReallocator(input);
            reallocator.Run();

            Assert.That(reallocator.Steps, Is.EqualTo(5));
            Assert.That(reallocator.LoopSize, Is.EqualTo(4));
        }
    }
}
using Core.Puzzles.Year2017.Day06;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2017Tests
{
    public class Year2017Day06Tests
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
using Core.Spinlock;
using NUnit.Framework;

namespace Tests
{
    public class SpinlockTests
    {
        [Test]
        public void NextValueIsCorrect()
        {
            const int input = 3;
            var runner = new SpinlockRunner(input);
            runner.Run(2017);

            Assert.That(runner.NextValue, Is.EqualTo(638));
        }
    }
}
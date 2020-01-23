using Core.DigitalPlumber;
using NUnit.Framework;

namespace Tests
{
    public class DigitalPlumberTests
    {
        [Test]
        public void CountsNumbersInGroupZero()
        {
            const string input = @"
0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5";

            var pipes = new Pipes(input);

            Assert.That(pipes.PipesLeadingToZero, Is.EqualTo(6));
        }
    }
}
using Core.Puzzles.Year2020.Day25;
using NUnit.Framework;

namespace Tests
{
    public class Year2020Day25Tests
    {
        private const string Input = @"
5764801
17807724";

        [Test]
        public void FindEncryptionKey()
        {
            var finder = new EncryptionKeyFinder(Input);
            var key = finder.FindKey();

            Assert.That(key, Is.EqualTo(14897079));
        }
    }
}
using Core.OneTimePad;
using NUnit.Framework;

namespace Tests
{
    public class OneTimePadTests
    {
        [Test]
        public void GeneratesCorrectKeys()
        {
            const string input = "abc";

            var generator = new KeyGenerator(input);

            Assert.That(generator.IndexOf64thKey, Is.EqualTo(22728));
        }

        [Test]
        public void GeneratesCorrectStretchedKeys()
        {
            const string input = "abc";

            var generator = new KeyGenerator(input, true);

            Assert.That(generator.IndexOf64thKey, Is.EqualTo(22551));
        }
    }
}
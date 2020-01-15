using Core.KnotHash;
using NUnit.Framework;

namespace Tests
{
    public class KnotHashTests
    {
        [Test]
        public void SimulatesHash()
        {
            const string input = "3,4,1,5";
            var hasher = new KnotHasher(5, input);

            Assert.That(hasher.Checksum, Is.EqualTo(12));
        }
    }
}
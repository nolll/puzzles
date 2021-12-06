using System.ComponentModel.DataAnnotations;
using Core.Puzzles.Year2020.Day25;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class HotelDoorTests
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
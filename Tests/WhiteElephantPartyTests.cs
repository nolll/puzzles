using Core.WhiteElephants;
using NUnit.Framework;

namespace Tests
{
    public class WhiteElephantPartyTests
    {
        [Test]
        public void ThirdElfGetsAllPresents()
        {
            const int input = 5;

            var party = new WhiteElephantParty(input);

            Assert.That(party.Winner, Is.EqualTo(3));
        }
    }
}
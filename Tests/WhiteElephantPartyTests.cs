using Core.WhiteElephants;
using NUnit.Framework;

namespace Tests
{
    public class WhiteElephantPartyTests
    {
        [Test]
        public void StealFromNextElf_ThirdElfGetsAllPresents()
        {
            const int input = 5;

            var party = new WhiteElephantParty(input);
            var winner = party.StealFromNextElf();

            Assert.That(winner, Is.EqualTo(3));
        }

        [Test]
        public void StealFromAcrossTheCircle_SecondElfGetsAllPresents()
        {
            const int input = 5;

            var party = new WhiteElephantParty(input);
            var winner = party.StealFromElfAcrossCircle();

            Assert.That(winner, Is.EqualTo(2));
        }
    }
}
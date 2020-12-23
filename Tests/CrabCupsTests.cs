using Core.CrabCups;
using Core.MakeFuel;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class CrabCupsTests
    {
        [Test]
        public void ResultAfter10MovesIsCorrect()
        {
            const int input = 389125467;

            var game = new CrabCupsGame(input);
            var result = game.Play(10);

            Assert.That(result, Is.EqualTo("92658374"));
        }
    }
}
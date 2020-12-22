using Core.CardCombat;
using Core.MakeFuel;
using NUnit.Framework;

namespace Tests
{
    public class CardCombatTests
    {
        [Test]
        public void WinningScoreIs306()
        {
            const string input = @"
Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

            var game = new CardCombatGame(input);
            var score = game.Play();

            Assert.That(score, Is.EqualTo(306));
        }
    }
}
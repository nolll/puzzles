using ConsoleApp.Puzzles.Year2020.Day22;
using NUnit.Framework;

namespace Tests
{
    public class CardCombatTests
    {
        [Test]
        public void NormalGame_WinningScoreIs306()
        {
            var game = new CardCombatGame(Input);
            var score = game.Play();

            Assert.That(score, Is.EqualTo(306));
        }

        [Test]
        public void InfiniteGame_Ends()
        {
            const string input = @"
Player 1:
43
19

Player 2:
2
29
14";

            var game = new CardCombatGame(input);
            game.PlayRecursive();
            const bool ended = true;

            Assert.That(ended, Is.True);
        }

        [Test]
        public void RecursiveGame_WinningScoreIs306()
        {
            var game = new CardCombatGame(Input);
            var score = game.PlayRecursive();

            Assert.That(score, Is.EqualTo(291));
        }

        private const string Input = @"
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
    }
}
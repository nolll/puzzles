using Core.CardShuffling;
using NUnit.Framework;

namespace Tests
{
    public class CardShufflerTests
    {
        [Test]
        public void DealIntoNewStack()
        {
            var deck = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var shuffler = new CardShuffler(deck);
            shuffler.Reverse();

            var expectedDeck = new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            Assert.That(shuffler.Deck, Is.EqualTo(expectedDeck));
        }

        [Test]
        public void PositiveCut()
        {
            var deck = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var shuffler = new CardShuffler(deck);
            shuffler.Cut(3);

            var expectedDeck = new[] { 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 };
            Assert.That(shuffler.Deck, Is.EqualTo(expectedDeck));
        }

        [Test]
        public void NegativeCut()
        {
            var deck = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var shuffler = new CardShuffler(deck);
            shuffler.Cut(-4);

            var expectedDeck = new[] { 6, 7, 8, 9, 0, 1, 2, 3, 4, 5 };
            Assert.That(shuffler.Deck, Is.EqualTo(expectedDeck));
        }

        [Test]
        public void Increment()
        {
            var deck = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var shuffler = new CardShuffler(deck);
            shuffler.Increment(3);

            var expectedDeck = new[] { 0, 7, 4, 1, 8, 5, 2, 9, 6, 3 };
            Assert.That(shuffler.Deck, Is.EqualTo(expectedDeck));
        }

        [Test]
        public void ShuffleMany()
        {
            var deck = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var shuffler = new CardShuffler(deck);

            const string input = @"
deal into new stack
cut -2
deal with increment 7
cut 8
cut -4
deal with increment 7
cut 3
deal with increment 9
deal with increment 3
cut -1";
            shuffler.Shuffle(input);

            var expectedDeck = new[] { 9, 2, 5, 8, 1, 4, 7, 0, 3, 6 };
            Assert.That(shuffler.Deck, Is.EqualTo(expectedDeck));
        }
    }
}
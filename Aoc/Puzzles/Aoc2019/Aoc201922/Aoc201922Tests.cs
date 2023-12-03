using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2019.Aoc201922;

public class Aoc201922Tests
{
    [Test]
    public void DealIntoNewStack()
    {
        var deck = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var shuffler = new CardShuffler();
        deck = shuffler.Reverse(deck).ToArray();

        var expectedDeck = new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        deck.Should().BeEquivalentTo(expectedDeck);
    }

    [Test]
    public void PositiveCut()
    {
        var deck = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var shuffler = new CardShuffler();
        deck = shuffler.Cut(deck, 3).ToArray();

        var expectedDeck = new[] { 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 };
        deck.Should().BeEquivalentTo(expectedDeck);
    }

    [Test]
    public void NegativeCut()
    {
        var deck = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var shuffler = new CardShuffler();
        deck = shuffler.Cut(deck, -4).ToArray();

        var expectedDeck = new[] { 6, 7, 8, 9, 0, 1, 2, 3, 4, 5 };
        deck.Should().BeEquivalentTo(expectedDeck);
    }

    [Test]
    public void Increment()
    {
        var deck = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var shuffler = new CardShuffler();
        deck = shuffler.Increment(deck, 3).ToArray();

        var expectedDeck = new[] { 0, 7, 4, 1, 8, 5, 2, 9, 6, 3 };
        deck.Should().BeEquivalentTo(expectedDeck);
    }

    [Test]
    public void ShuffleMany()
    {
        var shuffler = new CardShuffler();

        const string input = """
deal into new stack
cut -2
deal with increment 7
cut 8
cut -4
deal with increment 7
cut 3
deal with increment 9
deal with increment 3
cut -1
""";

        var deck = shuffler.Shuffle(10, input);

        var expectedDeck = new[] { 9, 2, 5, 8, 1, 4, 7, 0, 3, 6 };
        deck.Should().BeEquivalentTo(expectedDeck);
    }
}
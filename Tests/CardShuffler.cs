using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class CardShuffler
    {
        public IList<int> Deck { get; private set; }

        public CardShuffler(IList<int> deck)
        {
            Deck = deck;
        }

        public void Reverse()
        {
            Deck = Deck.Reverse().ToList();
        }

        public void Cut(int count)
        {
            var offset = count < 0
                ? Deck.Count + count
                : count;

            var itemsToMove = Deck.Take(offset);
            var newDeck = Deck.Skip(offset).ToList();
            newDeck.AddRange(itemsToMove);
            Deck = newDeck;
        }

        public void Increment(int n)
        {
            var newDeck = new int[Deck.Count];
            var position = 0;
            for (var i = 0; i < Deck.Count; i++)
            {
                var card = Deck[i];
                newDeck[position] = card;
                position += n;
                if (position > Deck.Count - 1)
                    position -= Deck.Count;
            }

            Deck = newDeck;
        }
    }
}
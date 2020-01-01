using System.Collections.Generic;
using System.Linq;

namespace Core.CardShuffling
{
    public class CardShuffler
    {
        public IList<int> Deck { get; private set; }

        public CardShuffler(IList<int> deck)
        {
            Deck = deck;
        }

        public CardShuffler(int size)
        {
            Deck = new List<int>();
            for (var i = 0; i < size; i++)
            {
                Deck.Add(i);
            }
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

        public void Shuffle(string input)
        {
            Shuffle(input.Trim().Split('\n').Select(o => o.Trim()).ToList());
        }

        public void Shuffle(IList<string> shuffles)
        {
            foreach (var shuffle in shuffles)
            {
                if (shuffle == "deal into new stack")
                {
                    Reverse();
                }
                else if (shuffle.StartsWith("deal with increment"))
                {
                    var n = int.Parse(shuffle.Split(" ").Last());
                    Increment(n);
                }
                else if (shuffle.StartsWith("cut"))
                {
                    var n = int.Parse(shuffle.Split(" ").Last());
                    Cut(n);
                }
            }
        }
    }
}
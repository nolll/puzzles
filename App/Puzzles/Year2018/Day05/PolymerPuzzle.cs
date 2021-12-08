using System.Collections.Generic;
using System.Linq;

namespace App.Puzzles.Year2018.Day05
{
    public class PolymerPuzzle
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly List<string> _pairs;
        private readonly Dictionary<char, char> _charLookup;

        public PolymerPuzzle()
        {
            _pairs = GetPairs();
            var uppercase = Letters.ToCharArray();
            var lowercase = Letters.ToLower().ToCharArray();

            _charLookup = new Dictionary<char, char>();
            for (var i = 0; i < lowercase.Length; i++)
            {
                _charLookup.Add(lowercase[i], uppercase[i]);
                _charLookup.Add(uppercase[i], lowercase[i]);
            }
        }

        public string GetReducedPolymer(string polymer)
        {
            var list = ConvertToList(polymer);
            list = Reduce(list);
            return ConvertToString(list);
        }

        public string GetImprovedPolymer(string polymer)
        {
            return ImproveAndReduce(polymer);
        }

        private LinkedList<char> ConvertToList(string str)
        {
            return new(str.ToCharArray());
        }

        private string ConvertToString(LinkedList<char> list)
        {
            return new(list.ToArray());
        }

        private static List<string> GetPairs()
        {
            var pairs = new List<string>();
            foreach (var c in Letters)
            {
                var pair = $"{c}{c.ToString().ToLower()}";
                var reverse = $"{c.ToString().ToLower()}{c}";
                pairs.Add(pair);
                pairs.Add(reverse);
            }
            
            return pairs;
        }

        private LinkedList<char> Reduce(LinkedList<char> list)
        {
            var length = list.Count;
            ReplaceLetters(list);
            if (list.Count != length)
            {
                return Reduce(list);
            }

            return list;
        }

        private void ReplaceLetters(LinkedList<char> list)
        {
            var currentItem = list.First;
            var nextItem = currentItem?.Next;
            while (nextItem != null)
            {
                if (IsPair(currentItem.Value, nextItem.Value))
                {
                    var newCurrent = nextItem.Next;
                    list.Remove(currentItem);
                    list.Remove(nextItem);
                    currentItem = newCurrent;
                    nextItem = currentItem?.Next;
                }
                else
                {
                    currentItem = nextItem;
                    nextItem = currentItem.Next;
                }
            }
        }

        private bool IsPair(char a, char b)
        {
            return a == _charLookup[b];
        }
        
        private string ImproveAndReduce(string polymer)
        {
            var shortest = polymer;
            foreach (var c in Letters)
            {
                var character = c.ToString();
                var improved = polymer.Replace(character, "").Replace(character.ToLower(), "");
                var list = ConvertToList(improved);
                var reduced = Reduce(list);
                
                if (reduced.Count < shortest.Length)
                    shortest = ConvertToString(reduced);
            }

            return shortest;
        }
    }
}
using System.Collections.Generic;

namespace Core.Polymers
{
    public class PolymerPuzzle
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly List<string> _pairs = GetPairs();

        public string GetReducedPolymer(string polymer)
        {
            return Reduce(polymer);
        }

        public string GetImprovedPolymer(string polymer)
        {
            return ImproveAndReduce(polymer);
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

        private string Reduce(string polymer)
        {
            var reduced = ReplaceLetters(polymer);
            if (reduced != polymer)
            {
                return Reduce(reduced);
            }

            return reduced;
        }

        private string ImproveAndReduce(string polymer)
        {
            var shortestPolymer = polymer;
            foreach (var c in Letters)
            {
                var character = c.ToString();
                var improved = polymer.Replace(character, "").Replace(character.ToLower(), "");
                var reduced = Reduce(improved);
                if (reduced.Length < shortestPolymer.Length)
                    shortestPolymer = reduced;
            }

            return shortestPolymer;
        }

        private string ReplaceLetters(string str)
        {
            var returnVal = str;
            foreach (var pair in _pairs)
            {
                returnVal = returnVal.Replace(pair, "");
            }
            return returnVal;
        }
    }
}
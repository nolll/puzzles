using System.Linq;

namespace Core.NaughtyOrNice
{
    public class NaughtyOrNiceEvaluator
    {
        private const string Vowels = "aeiou";

        public int GetNiceCount(string input)
        {
            var strings = input.Split('\n').Select(o => o.Trim());
            return strings.Count(IsNice);
        }

        public bool IsNice(string input)
        {
            if (ContainsForbiddenSubstrings(input))
                return false;

            if (!ContainsRepeatedCharacter(input))
                return false;

            if (GetVowelCount(input) < 3)
                return false;

            return true;
        }

        private bool ContainsForbiddenSubstrings(string input)
        {
            if (input.Contains("ab"))
                return true;
            if (input.Contains("cd"))
                return true;
            if (input.Contains("pq"))
                return true;
            if (input.Contains("xy"))
                return true;
            return false;
        }

        private bool ContainsRepeatedCharacter(string input)
        {
            var lastChar = '-';
            foreach (var c in input)
            {
                if (c == lastChar)
                    return true;

                lastChar = c;
            }

            return false;
        }

        private int GetVowelCount(string input)
        {
            return input.Count(IsVowel);
        }

        private bool IsVowel(char c)
        {
            return Vowels.Contains(c);
        }
    }
}
using System.Linq;

namespace Core.UniqueWordPasswords
{
    public class PassphraseValidator
    {
        public int GetValidCount(string input)
        {
            return input.Split('\n').Count(IsValid);
        }

        public bool IsValid(string input)
        {
            var words = input.Split(" ").Select(o => o.Trim());
            foreach (var word in words)
            {
                if (words.Count(o => o == word) > 1)
                    return false;
            }

            return true;
        }
    }
}
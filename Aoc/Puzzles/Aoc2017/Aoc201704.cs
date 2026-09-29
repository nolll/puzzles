using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("High-Entropy Passphrases")]
public class Aoc201704 : AocPuzzle
{
    [Puzzle("b3e7e2fe95c58aa22d1f35b7cd9c041a")]
    public int Part1(string input)
    {
        var validator = new PassphraseValidator();
        return validator.GetValidCount1(input);
    }

    [Puzzle("960adf2fc72eac4faf8f3f5de0d2e01a")]
    public int Part2(string input) => new PassphraseValidator().GetValidCount2(input);
    
    public class PassphraseValidator
    {
        public int GetValidCount1(string input) => input.Split(LineBreaks.Single).Count(IsValid1);
        public int GetValidCount2(string input) => input.Split(LineBreaks.Single).Count(IsValid2);

        public bool IsValid1(string input)
        {
            var words = input.Split(" ").Select(o => o.Trim()).ToList();
            foreach (var word in words)
            {
                if (words.Count(o => o == word) > 1)
                    return false;
            }

            return true;
        }

        public bool IsValid2(string input)
        {
            var words = input.Split(" ").Select(o => string.Concat(o.Trim().OrderBy(c => c))).ToList();
            foreach (var word in words)
            {
                if (words.Count(o => o == word) > 1)
                    return false;
            }

            return true;
        }
    }
}
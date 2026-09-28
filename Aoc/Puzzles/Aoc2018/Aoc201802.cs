using System.Text;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Inventory Management System")]
public class Aoc201802 : AocPuzzle
{
    [Puzzle("e7ee8e8967be0ed8c2fe23ef3e7d765e")]
    public int Part1(string input) => new BoxChecksumPuzzle(input).Checksum;

    [Puzzle("dec3acac891412bfec2fff6435645abd")]
    public string Part2(string input) => new SimilarIdsPuzzle(input).CommonLetters;
    
    public class BoxChecksumPuzzle
    {
        public int Checksum { get; }

        public BoxChecksumPuzzle(string input)
        {
            var ids = input.Split(LineBreaks.Single);
            var idCharacteristics = ids.Select(o => new IdCharacteristics(o.Trim())).ToList();
            var doubleCount = idCharacteristics.Count(o => o.HasDoubleChars);
            var tripleCount = idCharacteristics.Count(o => o.HasTripleChars);
            Checksum = doubleCount * tripleCount;
        }
    }
    
    public class IdCharacteristics
    {
        public bool HasDoubleChars { get; }
        public bool HasTripleChars { get; }

        public IdCharacteristics(string id)
        {
            var charCounts = new Dictionary<char, int>();
            foreach (var c in id)
            {
                if (!charCounts.TryAdd(c, 1))
                {
                    charCounts[c]++;
                }
            }

            foreach (var val in charCounts.Values)
            {
                if (val == 2)
                {
                    HasDoubleChars = true;
                }

                if (val == 3)
                {
                    HasTripleChars = true;
                }
            }
        }
    }
    
    public class SimilarIdsPuzzle
    {
        public string CommonLetters { get; }

        public SimilarIdsPuzzle(string input)
        {
            var ids = input.Split(LineBreaks.Single);
            var similarIds = GetSimilarIds(ids);
            if (similarIds.Count != 2)
                throw new WrongNumberOfSimilarIdsException(similarIds);

            CommonLetters = GetCommonLetters(similarIds[0], similarIds[1]);
        }

        public static IList<string> GetSimilarIds(IList<string> ids)
        {
            foreach (var id in ids)
            {
                var similarId = ids.FirstOrDefault(o => LevenshteinDistance.Compute(id, o) == 1);
                if (similarId != null)
                    return [id, similarId];
            }
            return [];
        }

        public static string GetCommonLetters(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                throw new StringsAreDifferentLengthsException(str1, str2);

            var sb = new StringBuilder();
            for (var i = 0; i < str1.Length; i++)
            {
                var c = str1[i];
                if (c == str2[i]) 
                    sb.Append(c);
            }

            return sb.ToString();
        }
    }
    
    public class StringsAreDifferentLengthsException : Exception
    {
        public StringsAreDifferentLengthsException(string str1, string str2) : base($"Strings {str1} and {str2} are different length.")
        {
        }
    }
    
    public class WrongNumberOfSimilarIdsException : Exception
    {
        public WrongNumberOfSimilarIdsException(IList<string> ids) 
            : base($"Wrong number of similar ids. Should be two, was {ids.Count}.")
        {
        }
    }
}
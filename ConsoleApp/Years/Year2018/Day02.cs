using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Frequencies;
using Core.Tools;
using Data.Inputs;

namespace ConsoleApp.Years.Year2018
{
    public class Day02 : Day
    {
        public Day02() : base(2)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var boxChecksumPuzzle = new BoxChecksumPuzzle(InputData.BoxIds);
            Console.WriteLine($"Checksum: {boxChecksumPuzzle.Checksum}");

            var similarIdsPuzzle = new SimilarIdsPuzzle(InputData.BoxIds);
            Console.WriteLine($"Common letters: {similarIdsPuzzle.CommonLetters}");

            WritePartTitle();
        }
    }

    public class BoxChecksumPuzzle
    {
        public int Checksum { get; }

        public BoxChecksumPuzzle(string input)
        {
            var ids = StringListReader.Read(input);
            var idCharacteristics = ids.Select(o => new IdCharacteristics(o.Trim())).ToList();
            var doubleCount = idCharacteristics.Count(o => o.HasDoubleChars);
            var tripleCount = idCharacteristics.Count(o => o.HasTripleChars);
            Checksum = doubleCount * tripleCount;
        }
    }

    public class SimilarIdsPuzzle
    {
        public string CommonLetters { get; }

        public SimilarIdsPuzzle(string input)
        {
            var ids = StringListReader.Read(input);
            var similarIds = GetSimilarIds(ids);
            if (similarIds.Count != 2)
                throw new WrongNumberOfSimilarIdsException(similarIds);

            CommonLetters = GetCommonLetters(similarIds[0], similarIds[1]);
        }

        public static List<string> GetSimilarIds(List<string> ids)
        {
            foreach (var id in ids)
            {
                var similarId = ids.FirstOrDefault(o => LevenshteinDistance.Compute(id, o) == 1);
                if (similarId != null)
                    return new List<string> { id, similarId };
            }
            return new List<string>();
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
                {
                    sb.Append(c);
                }
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
        public WrongNumberOfSimilarIdsException(List<string> ids) : base($"Wrong number of similar ids. Should be two, was {ids.Count}.")
        {
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

    public static class LevenshteinDistance
    {
        // Calculates similarity of strings. Shorter distance means more similar strings.
        // Algorithm from https://www.dotnetperls.com/levenshtein
        public static int Compute(string s, string t)
        {
            var n = s.Length;
            var m = t.Length;
            var d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (var i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (var j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (var i = 1; i <= n; i++)
            {
                //Step 4
                for (var j = 1; j <= m; j++)
                {
                    // Step 5
                    var cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            // Step 7
            return d[n, m];
        }
    }

}
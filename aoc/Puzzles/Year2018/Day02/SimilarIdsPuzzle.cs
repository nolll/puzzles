using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aoc.Common.Strings;

namespace Aoc.Puzzles.Year2018.Day02;

public class SimilarIdsPuzzle
{
    public string CommonLetters { get; }

    public SimilarIdsPuzzle(string input)
    {
        var ids = PuzzleInputReader.ReadLines(input);
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
using System.Text;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Inventory Management System")]
public class Aoc201802 : AocPuzzle
{
    [Puzzle("e7ee8e8967be0ed8c2fe23ef3e7d765e")]
    public int Part1(string input)
    {
        var characteristics = ParsePart1(input);
        var doubleCount = characteristics.Count(o => o.HasDoubleChars);
        var tripleCount = characteristics.Count(o => o.HasTripleChars);
        return doubleCount * tripleCount;
    }

    [Puzzle("dec3acac891412bfec2fff6435645abd")]
    public string Part2(string input)
    {
        var words = input.Split(LineBreaks.Single);
        var similarIds = GetSimilarIds(words);
        return GetCommonLetters(similarIds[0], similarIds[1]);
    }

    public IList<string> GetSimilarIds(IList<string> ids)
    {
        foreach (var id in ids)
        {
            var similarId = ids.FirstOrDefault(o => LevenshteinDistance.Compute(id, o) == 1);
            if (similarId != null)
                return [id, similarId];
        }

        return [];
    }

    public string GetCommonLetters(string str1, string str2)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < str1.Length; i++)
        {
            var c = str1[i];
            if (c == str2[i])
                sb.Append(c);
        }

        return sb.ToString();
    }

    private static IdCharacteristics[] ParsePart1(string input) =>
        [.. input.Split(LineBreaks.Single).Select(o => new IdCharacteristics(o.Trim()))];

    private class IdCharacteristics
    {
        public bool HasDoubleChars { get; }
        public bool HasTripleChars { get; }

        public IdCharacteristics(string id)
        {
            var counts = id.GroupBy(o => o).Select(o => o.Count()).ToArray();
            HasDoubleChars = counts.Any(o => o == 2);
            HasTripleChars = counts.Any(o => o == 3);
        }
    }
}
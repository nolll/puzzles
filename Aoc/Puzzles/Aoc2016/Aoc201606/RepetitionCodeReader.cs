using System.Text;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201606;

public class RepetitionCodeReader
{
    public string ReadMostCommon(string input)
    {
        var strings = input.Trim().Split(LineBreaks.Single).Select(o => o.Trim()).ToList();
        var messageLength = strings.First().Length;
        var message = new StringBuilder();

        for (var i = 0; i < messageLength; i++)
        {
            var index = i;
            var chars = string.Concat(strings.Select(s => s[index]));
            var mostCommonChar = chars.GroupBy(o => o).OrderByDescending(o => o.Count()).First().Key;
            message.Append(mostCommonChar);
        }

        return message.ToString();
    }

    public string ReadLeastCommon(string input)
    {
        var strings = input.Trim().Split(LineBreaks.Single).Select(o => o.Trim()).ToList();
        var messageLength = strings.First().Length;
        var message = new StringBuilder();

        for (var i = 0; i < messageLength; i++)
        {
            var index = i;
            var chars = string.Concat(strings.Select(s => s[index]));
            var leastCommonChar = chars.GroupBy(o => o).OrderBy(o => o.Count()).First().Key;
            message.Append(leastCommonChar);
        }

        return message.ToString();
    }
}
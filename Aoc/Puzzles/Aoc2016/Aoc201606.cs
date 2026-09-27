using System.Text;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Signals and Noise")]
public class Aoc201606 : AocPuzzle
{
    [Puzzle("d501463dd43fdef3d85d722210ab3940")]
    public string Part1(string input) => new RepetitionCodeReader().ReadMostCommon(input);

    [Puzzle("509675b487b1cf475001b9592fab4a95")]
    public string Part2(string input) => new RepetitionCodeReader().ReadLeastCommon(input);
    
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
}
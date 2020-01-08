using System.Linq;
using System.Text;

namespace Core.RepetitionCode
{
    public class RepetitionCodeReader
    {
        public string ReadMostCommon(string input)
        {
            var strings = input.Trim().Split('\n').Select(o => o.Trim()).ToList();
            var messageLength = strings.First().Length;
            var message = new StringBuilder();

            for (var i = 0; i < messageLength; i++)
            {
                var chars = string.Concat(strings.Select(s => s[i]));
                var mostCommonChar = chars.GroupBy(o => o).OrderByDescending(o => o.Count()).First().Key;
                message.Append(mostCommonChar);
            }

            return message.ToString();
        }

        public string ReadLeastCommon(string input)
        {
            var strings = input.Trim().Split('\n').Select(o => o.Trim()).ToList();
            var messageLength = strings.First().Length;
            var message = new StringBuilder();

            for (var i = 0; i < messageLength; i++)
            {
                var chars = string.Concat(strings.Select(s => s[i]));
                var mostCommonChar = chars.GroupBy(o => o).OrderBy(o => o.Count()).First().Key;
                message.Append(mostCommonChar);
            }

            return message.ToString();
        }
    }
}
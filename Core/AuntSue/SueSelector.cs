using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.AuntSue
{
    public class SueSelector
    {
        public int Number { get; }

        public SueSelector(string input)
        {
            var sues = ParseSues(input);
            var correctSue = sues.FirstOrDefault(o => o.IsCorrectSue);

            Number = correctSue?.Number ?? 0;
        }

        private IList<Sue> ParseSues(string input)
        {
            var rows = PuzzleInputReader.Read(input);
            return rows.Select(ParseSue).ToList();
        }

        private Sue ParseSue(string s)
        {
            var parts = s.Replace(":", "").Replace(",", "").Split(' ');
            var number = int.Parse(parts[1]);
            var sue = new Sue(number);
            sue.Set(parts[2], int.Parse(parts[3]));
            sue.Set(parts[4], int.Parse(parts[5]));
            sue.Set(parts[6], int.Parse(parts[7]));
            return sue;
        }
    }
}
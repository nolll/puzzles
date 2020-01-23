using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Tools;

namespace Core.SubterraneanSustainability
{
    public class PlantSpreader
    {
        public int PlantScore { get; }

        public PlantSpreader(string input)
        {
            var rows = PuzzleInputReader.Read(input);
            var state = rows.First().Split(' ')[2];
            const string padding = "..................................................";
            state = $"{padding}{state}{padding}";
            var rules = rows.Skip(2).Select(o => new PlantRule(o)).ToList();
            const int patternLength = 5;
            const int generations = 20;
            var generation = 0;

            while (generation < generations)
            {
                var sb = new StringBuilder();
                sb.Append("..");
                for (var i = 0; i < state.Length - patternLength + 1; i++)
                {
                    var subStr = state.Substring(i, patternLength);
                    var matchingPattern = rules.FirstOrDefault(o => o.Pattern == subStr);
                    var c = matchingPattern?.Result ?? '.';
                    sb.Append(c);
                }

                sb.Append("..");
                state = sb.ToString();
                generation++;
            }

            var score = 0;
            var index = -padding.Length;
            foreach (var c in state)
            {
                if (c == '#')
                    score += index;

                index++;
            }

            PlantScore = score;
        }
    }
}
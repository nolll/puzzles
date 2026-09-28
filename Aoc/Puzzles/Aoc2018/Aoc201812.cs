using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Subterranean Sustainability")]
public class Aoc201812 : AocPuzzle
{
    [Puzzle("0ed64899552ad3524168fa5d31b0aa8b")]
    public int Part1(string input) => new PlantSpreader(input).PlantScore20;

    [Puzzle("7efddf05168f7291240396f1a5263653")]
    public long Part2(string input) => new PlantSpreader(input).PlantScore50B;

    public class PlantSpreader
    {
        private readonly List<bool> _pots;
        public int PlantScore20 { get; }
        public long PlantScore50B { get; }

        public PlantSpreader(string input)
        {
            var rows = input.Split(LineBreaks.Single);
            var state = rows.First().Split(' ')[2];
            const string paddingStr =
                "..............................................................................................................................................................................................................................................................................................................................................................";
            state = $"{paddingStr}{state}{paddingStr}";
            _pots = GetPots(state);
            var rules = rows.Skip(2).Select(o => new PlantRule(o)).ToList();
            const int patternLength = 5;
            var generation = 0;
            var padding = paddingStr.Length;
            var lastScore = 0;
            var scoreDiff = 0;

            while (generation < 200)
            {
                Pad(2);
                var score = 0;
                var newPots = new List<bool>();
                for (var i = 0; i < _pots.Count - patternLength + 1; i++)
                {
                    var current = _pots.GetRange(i, 5);
                    var matchingPattern = rules.FirstOrDefault(o => o.IsMatch(current));
                    var p = matchingPattern?.Result ?? false;
                    newPots.Add(p);
                }

                _pots = newPots;

                var index = -padding;
                foreach (var p in _pots)
                {
                    if (p)
                        score += index;

                    index++;
                }

                generation++;
                scoreDiff = score - lastScore;
                lastScore = score;

                if (generation == 20)
                    PlantScore20 = lastScore;
            }

            var plantScore200 = lastScore;
            const long generationsLeft = 50000000000 - 200;

            PlantScore50B = generationsLeft * scoreDiff + plantScore200;
        }

        private void Pad(int padding)
        {
            for (var i = 0; i < padding; i++)
            {
                _pots.Insert(0, false);
                _pots.Add(false);
            }
        }

        private static List<bool> GetPots(string state) => state.Select(c => c == '#').ToList();
    }
    
    public class PlantRule
    {
        public bool[] Pattern { get; }
        public bool Result { get; }

        public PlantRule(string s)
        {
            var parts = s.Split(" => ");
            Pattern = parts[0].ToCharArray().Select(IsTrue).ToArray();
            Result = IsTrue(parts[1].First());
        }

        private bool IsTrue(char c)
        {
            return c == '#';
        }

        public bool IsMatch(List<bool> current)
        {
            return !current.Where((t, i) => t != Pattern[i]).Any();
        }
    }
}
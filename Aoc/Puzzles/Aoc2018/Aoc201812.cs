using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Subterranean Sustainability")]
public class Aoc201812 : AocPuzzle
{
    private const int Padding = 350;

    [Puzzle("0ed64899552ad3524168fa5d31b0aa8b")]
    public int Part1(string input) => Solve(input).plantScore20;

    [Puzzle("7efddf05168f7291240396f1a5263653")]
    public long Part2(string input) => Solve(input).plantScore50B;

    private (int plantScore20, long plantScore50B) Solve(string input)
    {
        var plantScore20 = 0;
        var rows = input.Split(LineBreaks.Single);
        var state = rows.First().Split(' ')[2];
        var paddingStr = string.Concat(Enumerable.Range(0, Padding).Select(_ => '.'));
        state = $"{paddingStr}{state}{paddingStr}";
        var pots = GetPots(state);
        var rules = rows.Skip(2).Select(o => new PlantRule(o)).ToList();
        const int patternLength = 5;
        var generation = 0;
        var lastScore = 0;
        var scoreDiff = 0;

        while (generation < 200)
        {
            Pad(pots, 2);
            var score = 0;
            var newPots = new List<bool>();
            for (var i = 0; i < pots.Count - patternLength + 1; i++)
            {
                var current = pots.GetRange(i, 5);
                var matchingPattern = rules.FirstOrDefault(o => o.IsMatch(current));
                var p = matchingPattern?.Result ?? false;
                newPots.Add(p);
            }

            pots = newPots;

            var index = -Padding;
            foreach (var p in pots)
            {
                if (p)
                    score += index;

                index++;
            }

            generation++;
            scoreDiff = score - lastScore;
            lastScore = score;

            if (generation == 20)
                plantScore20 = lastScore;
        }

        var plantScore200 = lastScore;
        const long generationsLeft = 50000000000 - 200;

        var plantScore50B = generationsLeft * scoreDiff + plantScore200;
        return (plantScore20, plantScore50B);
    }

    private static void Pad(List<bool> pots, int padding)
    {
        for (var i = 0; i < padding; i++)
        {
            pots.Insert(0, false);
            pots.Add(false);
        }
    }

    private static List<bool> GetPots(string state) => [.. state.Select(c => c == '#')];

    private class PlantRule
    {
        private readonly bool[] _pattern;
        public bool Result { get; }

        public PlantRule(string s)
        {
            var parts = s.Split(" => ");
            _pattern = parts[0].ToCharArray().Select(IsTrue).ToArray();
            Result = IsTrue(parts[1].First());
        }

        private static bool IsTrue(char c) => c == '#';
        public bool IsMatch(List<bool> current) => !current.Where((t, i) => t != _pattern[i]).Any();
    }
}
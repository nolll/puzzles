using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201812;

public class PlantSpreader
{
    private readonly List<bool> _pots;
    public int PlantScore20 { get; }
    public long PlantScore50B { get; }

    public PlantSpreader(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var state = rows.First().Split(' ')[2];
        const string paddingStr = "..............................................................................................................................................................................................................................................................................................................................................................";
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

            if(generation == 20)
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
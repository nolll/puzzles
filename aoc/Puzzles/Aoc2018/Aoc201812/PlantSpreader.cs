using System.Collections.Generic;
using System.Linq;
using Common.Strings;

namespace Aoc.Puzzles.Aoc2018.Aoc201812;

public class PlantSpreader
{
    private readonly List<bool> _pots;
    private int _padding;
    public int PlantScore20 { get; }
    public long PlantScore50B { get; }

    public PlantSpreader(string input)
    {
        var rows = PuzzleInputReader.ReadLines(input);
        var state = rows.First().Split(' ')[2];
        var paddingStr = "..............................................................................................................................................................................................................................................................................................................................................................";
        state = $"{paddingStr}{state}{paddingStr}";
        _pots = GetPots(state);
        var rules = rows.Skip(2).Select(o => new PlantRule(o)).ToList();
        const int patternLength = 5;
        var generation = 0;
        _padding = paddingStr.Length;
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

            var index = -_padding;
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
        var generationsLeft = 50000000000 - 200;

        PlantScore50B = generationsLeft * scoreDiff + plantScore200;
    }

    private string Print(IList<bool> bools)
    {
        return string.Concat(bools.Select(o => o ? '#' : '.'));
    }

    private void Pad()
    {
        if (_pots[0])
        {
            _pots.Insert(0, false);
            _padding++;
        }

        if (_pots[1])
        {
            _pots.Insert(0, false);
            _padding++;
        }

        if (_pots[^1])
        {
            _pots.Add(false);
        }

        if (_pots[^2])
        {
            _pots.Add(false);
        }
    }

    private void Pad(int padding)
    {
        for (var i = 0; i < padding; i++)
        {
            _pots.Insert(0, false);
            _pots.Add(false);
        }
    }

    private List<bool> GetPots(string state)
    {
        return state.Select(c => c == '#').ToList();
    }
}
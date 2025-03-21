using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202402;

[Name("Sensors and Circuits")]
public class Codyssi202402 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var sum = input.Split(LineBreaks.Single).Select((t, i) => t == "TRUE" ? i + 1 : 0).Sum();

        return new PuzzleResult(sum, "129ad912c3dd4bdfd31569b370017fcc");
    }

    public PuzzleResult Part2(string input)
    {
        var bools = input.Split(LineBreaks.Single).Select(bool.Parse).ToList();
        var gates = new List<(bool, bool)>();
        for (var i = 0; i < bools.Count; i += 2)
        {
            gates.Add((bools[i], bools[i + 1]));
        }

        var count = gates.Where(EvaluateGate).Count();

        return new PuzzleResult(count, "742e9c5b98a1f2e9dfe76f5e8a1f560d");
    }

    public PuzzleResult Part3(string input)
    {
        var bools = input.Split(LineBreaks.Single).Select(bool.Parse).ToList();
        var count = bools.Count(o => o);;
        while (bools.Count > 1)
        {
            var gates = new List<(bool, bool)>();
            for (var i = 0; i < bools.Count; i += 2)
            {
                gates.Add((bools[i], bools[i + 1]));
            }

            bools = gates.Select(EvaluateGate).ToList();
            count += bools.Count(o => o);
        }
        
        return new PuzzleResult(count, "a772b930c8006d31219141df44c6b8e0");
    }

    private bool EvaluateGate((bool, bool) gate, int index)
    {
        var (a, b) = gate;
        return index % 2 == 0 && a && b || index % 2 == 1 && (a || b);
    }
}
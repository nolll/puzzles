using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201715;

public class GeneratorDuel(long startValueA, long startValueB)
{
    private readonly Generator _generatorA = new(startValueA, 16807, 4);
    private readonly Generator _generatorB = new(startValueB, 48271, 8);

    public int FinalCount { get; private set; }

    public static GeneratorDuel Parse(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var startValues = rows.Select(o => long.Parse(o.Split(' ').Last())).ToList();

        return new GeneratorDuel(startValues.First(), startValues.Last());
    }

    public void Run(int iterations)
    {
        var count = 0;
        var i = 0;
        while (i < iterations)
        {
            _generatorA.Process();
            _generatorB.Process();
            if (_generatorA.ShortLastValue == _generatorB.ShortLastValue)
                count++;
            i++;
        }

        FinalCount = count;
    }

    public void Run2(int pairCount)
    {
        var generatorAStrings = new List<short>();
        var generatorBStrings = new List<short>();
        var count = 0;
        var i = 0;
        while (generatorAStrings.Count < pairCount)
        {
            _generatorA.Process();
            if (_generatorA.IsValid)
                generatorAStrings.Add(_generatorA.ShortLastValue);
            i++;
        }

        i = 0;
        while (generatorBStrings.Count < pairCount)
        {
            _generatorB.Process();
            if (_generatorB.IsValid)
                generatorBStrings.Add(_generatorB.ShortLastValue);
            i++;
        }

        for (i = 0; i < pairCount; i++)
        {
            if (generatorAStrings[i] == generatorBStrings[i])
                count++;
        }

        FinalCount = count;
    }
}
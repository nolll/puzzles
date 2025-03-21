using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201715;

public class GeneratorDuel
{
    private readonly Generator _generatorA;
    private readonly Generator _generatorB;

    public int FinalCount { get; private set; }

    public GeneratorDuel(long startValueA, long startValueB)
    {
        _generatorA = new Generator(startValueA, 16807, 4);
        _generatorB = new Generator(startValueB, 48271, 8);
        FinalCount = 0;
    }

    public static GeneratorDuel Parse(string input)
    {
        var rows = StringReader.ReadLines(input);
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
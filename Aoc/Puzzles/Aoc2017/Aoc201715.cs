using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Dueling Generators")]
public class Aoc201715 : AocPuzzle
{
    private const long FactorA = 16807;
    private const long FactorB = 48271;
    private const int ValidationMultipleA = 4;
    private const int ValidationMultipleB = 8;
    
    [Puzzle("4eda86461504e63d609bceb54bbafa32")]
    public int Part1(string input) => Run(input, 40_000_000);

    [Puzzle("0e673f0bbb3b57c839d9267b2231a741")]
    public int Part2(string input) => Run2(input, 5_000_000);

    public int Run(string input, int iterations)
    {
        var (a, b) = CreateGenerators(input);
        var count = 0;
        var i = 0;
        while (i < iterations)
        {
            a.Process();
            b.Process();
            if (a.ShortLastValue == b.ShortLastValue)
                count++;
            i++;
        }

        return count;
    }

    public int Run2(string input, int pairCount)
    {
        var (a, b) = CreateGenerators(input);
        var aValues = GetValues(a, pairCount).ToList();
        var bValues = GetValues(b, pairCount).ToList();

        var count = 0;
        for (var i = 0; i < pairCount; i++)
        {
            if (aValues[i] == bValues[i])
                count++;
        }

        return count;
    }

    private static IEnumerable<short> GetValues(Generator generator, int pairCount)
    {
        var count = 0;
        while (count < pairCount)
        {
            generator.Process();
            if (!generator.IsValid)
                continue;
            
            yield return generator.ShortLastValue;
            count++;
        }
    }

    private static (Generator, Generator) CreateGenerators(string input)
    {
        var (a, b) = Parse(input);
        return (new Generator(a, FactorA, ValidationMultipleA), new Generator(b, FactorB, ValidationMultipleB));
    }

    private static (long, long) Parse(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var startValues = rows.Select(o => long.Parse(o.Split(' ').Last())).ToList();
        return (startValues.First(), startValues.Last());
    }
    
    private class Generator(long startValue, long factor, int validationMultiple)
    {
        private const long Divisor = 2147483647;
        private long _lastValue = startValue;
        public short ShortLastValue => (short)_lastValue;
        public bool IsValid => _lastValue % validationMultiple == 0;
        public void Process() => _lastValue = _lastValue * factor % Divisor;
    }
}
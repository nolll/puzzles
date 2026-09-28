using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Dueling Generators")]
public class Aoc201715 : AocPuzzle
{
    [Puzzle("4eda86461504e63d609bceb54bbafa32")]
    public int Part1(string input)
    {
        var duel = GeneratorDuel.Parse(input);
        duel.Run(40_000_000);
        return duel.FinalCount;
    }

    [Puzzle("0e673f0bbb3b57c839d9267b2231a741")]
    public int Part2(string input)
    {
        var duel = GeneratorDuel.Parse(input);
        duel.Run2(5_000_000);
        return duel.FinalCount;
    }
    
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
    
    public class Generator
    {
        private readonly int _validationMultiple;
        private const long Divisor = 2147483647;
        private readonly long _factor;
        private long _lastValue;
        public short ShortLastValue => (short) _lastValue;
        public bool IsValid => _lastValue % _validationMultiple == 0;

        public Generator(in long startValue, in long factor, in int validationMultiple)
        {
            _lastValue = startValue;
            _factor = factor;
            _validationMultiple = validationMultiple;
        }

        public void Process()
        {
            var product = _lastValue * _factor;
            _lastValue = product % Divisor;
        }
    }
}
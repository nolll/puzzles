using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.DuelingGenerators
{
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
            var rows = PuzzleInputReader.ReadLines(input);
            var startValues = rows.Select(o => long.Parse(o.Split(' ').Last())).ToList();

            return new GeneratorDuel(startValues.First(), startValues.Last());
        }

        public void Run(int iterations)
        {
            var result = new List<string>();
            var i = 0;
            while (i < iterations)
            {
                _generatorA.Process();
                _generatorB.Process();
                var a = _generatorA.BinaryLast16;
                var b = _generatorB.BinaryLast16;
                if (a == b)
                    result.Add(a);
                i++;
            }

            FinalCount = result.Count;
        }

        public void Run2(int pairCount)
        {
            var generatorAStrings = new List<string>();
            var generatorBStrings = new List<string>();
            var result = new List<string>();
            var i = 0;
            while (generatorAStrings.Count < pairCount)
            {
                _generatorA.Process();
                if (_generatorA.IsValid)
                    generatorAStrings.Add(_generatorA.BinaryLast16);
                i++;
            }

            i = 0;
            while (generatorBStrings.Count < pairCount)
            {
                _generatorB.Process();
                if (_generatorB.IsValid)
                    generatorBStrings.Add(_generatorB.BinaryLast16);
                i++;
            }

            for (i = 0; i < pairCount; i++)
            {
                if(generatorAStrings[i] == generatorBStrings[i])
                    result.Add(generatorAStrings[i]);
            }

            FinalCount = result.Count;
        }
    }
}
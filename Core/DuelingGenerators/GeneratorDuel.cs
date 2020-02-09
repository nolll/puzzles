using System.Collections.Generic;

namespace Core.DuelingGenerators
{
    public class GeneratorDuel
    {
        private Generator _generatorA;
        private Generator _generatorB;

        public int FinalCount { get; private set; }

        public GeneratorDuel(long startValueA, long startValueB)
        {
            _generatorA = new Generator(startValueA, 16807);
            _generatorB = new Generator(startValueB, 48271);
            FinalCount = 0;
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
                if(a == b)
                    result.Add(a);
                i++;
            }

            FinalCount = result.Count;
        }
    }
}
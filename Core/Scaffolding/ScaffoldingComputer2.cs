using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Computer;

namespace Core.Scaffolding
{
    public class ScaffoldingComputer2
    {
        private readonly ComputerInterface _computer;
        private long _output;

        private readonly int[] _mainRoutine = { 'A', ',', 'B', ',', 'C', ',', 'A', ',', 'B' };
        private readonly int[] _functionA = { 'R', ',', '6', ',', 'L', ',', '1', '0', ',', 'R', ',', '8', ',', 'R', ',', '8', ',', 'R', ',', '1', '2', ',', 'L', ',', '8', ',', 'L', ',', '1', '0', ',', 'R', ',', '6', ',', 'L', ',', '1', '0' };
        private readonly int[] _functionB = { 'R', ',', '8', ',', 'R', ',', '8', ',', 'R', ',', '1', '2', ',', 'L', ',', '1', '0', ',', 'R', ',', '6', ',', 'L', ',', '1', '0' };
        private readonly int[] _functionC = { 'R', ',', '1', '2', ',', 'L', ',', '8', ',', 'L', ',', '1', '0', ',', 'R', ',', '1', '2', ',', 'L', ',', '1', '0', ',', 'R', ',', '6', ',', 'L', ',', '1', '0' };

        private readonly IList<int> _inputSequence;

        public ScaffoldingComputer2(string program)
        {
            _computer = new ComputerInterface($"2{program.Substring(1)}", ReadInput, WriteOutput);
            _inputSequence = BuildInputSequence();
        }

        private IList<int> BuildInputSequence()
        {
            var inputSequence = new List<int>();
            inputSequence.AddRange(_mainRoutine);
            inputSequence.Add(10);
            inputSequence.AddRange(_functionA);
            inputSequence.Add(10);
            inputSequence.AddRange(_functionB);
            inputSequence.Add(10);
            inputSequence.AddRange(_functionC);
            inputSequence.Add(10);

            return inputSequence;
        }

        public long Run()
        {
            _computer.Start();
            return _output;
        }

        private long ReadInput()
        {
            if (_inputSequence.Any())
            {
                var val = _inputSequence.First();
                _inputSequence.RemoveAt(0);
                return val;
            }

            return 'n';
        }

        private void WriteOutput(long output)
        {
            _output = output;
        }
    }
}
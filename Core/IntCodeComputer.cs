using System.Linq;

namespace Core
{
    public class IntCodeComputer
    {
        private readonly string _input;
        private readonly int[] _startMemory;

        private const int ADD = 1;
        private const int MULTIPLY = 2;
        private const int END = 99;

        private int[] _memory;

        public IntCodeComputer(string input)
        {
            _startMemory = GetStartMemory(input);
        }

        public Result Run(int? noun = null, int? verb = null)
        {
            ResetMemory();
            if(noun != null)
                _memory[1] = noun.Value;

            if(verb != null)
                _memory[2] = verb.Value;

            var instructionPointer = 0;
            while (instructionPointer < _memory.Length)
            {
                var instruction = _memory[instructionPointer];

                if (instruction == ADD || instruction == MULTIPLY)
                {
                    var pos1 = _memory[instructionPointer + 1];
                    var pos2 = _memory[instructionPointer + 2];
                    var pos3 = _memory[instructionPointer + 3];
                    if (instruction == ADD)
                        _memory[pos3] = _memory[pos1] + _memory[pos2];
                    else
                        _memory[pos3] = _memory[pos1] * _memory[pos2];
                }
                else if (instruction == END)
                {
                    break;
                }
                else
                {
                    throw new UnknownInstructionException(instruction);
                }

                instructionPointer += 4;
            }

            return new Result(_memory);
        }

        public class Result
        {
            private readonly int[] _memory;

            public string Output => string.Join(',', _memory.Select(o => o.ToString()));
            public int Integer => _memory[0];

            public Result(int[] memory)
            {
                _memory = memory;
            }
        }

        public int GetFirstPos()
        {
            return _memory[0];
        }

        private void ResetMemory()
        {
            _memory = _startMemory;
        }

        private static int[] GetStartMemory(string input)
        {
            var data = input.Trim();
            var massStrings = data.Split(',');
            return massStrings.Select(int.Parse).ToArray();
        }
    }
}
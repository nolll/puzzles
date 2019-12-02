using System;
using System.Linq;

namespace Core
{
    public class IntCodeComputer
    {
        private const string DefaultInput = "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,6,1,19,1,5,19,23,2,9,23,27,1,6,27,31,1,31,9,35,2,35,10,39,1,5,39,43,2,43,9,47,1,5,47,51,1,51,5,55,1,55,9,59,2,59,13,63,1,63,9,67,1,9,67,71,2,71,10,75,1,75,6,79,2,10,79,83,1,5,83,87,2,87,10,91,1,91,5,95,1,6,95,99,2,99,13,103,1,103,6,107,1,107,5,111,2,6,111,115,1,115,13,119,1,119,2,123,1,5,123,0,99,2,0,14,0";
        private const int ADD = 1;
        private const int MULTIPLY = 2;
        private const int END = 99;

        private readonly int[] _startMemory;
        private int[] _memory;

        public IntCodeComputer(string input = null)
        {
            _startMemory = GetStartMemory(input ?? DefaultInput);
            _memory = CopyMemory(_startMemory);
        }

        public Result Run(int? noun = null, int? verb = null)
        {
            _memory = CopyMemory(_startMemory);
            if (noun != null)
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

        private int[] CopyMemory(int[] memory)
        {
            var copy = new int[memory.Length];
            for (var i = 0; i < memory.Length; i++)
            {
                copy[i] = memory[i];
            }

            return copy;
        }

        private static int[] GetStartMemory(string input)
        {
            var data = input.Trim();
            var massStrings = data.Split(',');
            return massStrings.Select(int.Parse).ToArray();
        }
    }
}
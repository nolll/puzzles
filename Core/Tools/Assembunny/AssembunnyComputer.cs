using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Tools.Assembunny
{
    public class AssembunnyComputer
    {
        private readonly Dictionary<char, int> _registers;
        private int _index;
        private readonly AssembunnyInstruction[] _instructions;

        public int ValueA => _registers['a'];

        public AssembunnyComputer(string input, int c = 0)
        {
            _instructions = PuzzleInputReader.Read(input).Select(ParseInstruction).ToArray();
            _registers = new Dictionary<char, int>
            {
                ['a'] = 0, 
                ['b'] = 0, 
                ['c'] = c, 
                ['d'] = 0
            };
            _index = 0;
            
            while(_index < _instructions.Length)
            {
                var instruction = _instructions[_index];
                instruction.Execute();
            }
        }

        private void IncrementIndex(int steps = 1)
        {
            _index += steps;
        }

        public void SetValue(int value, char target)
        {
            _registers[target] = value;
            IncrementIndex();
        }

        public void CopyValue(char source, char target)
        {
            var value = _registers[source];
            SetValue(value, target);
        }

        public void JumpValueNotZero(int value, int steps)
        {
            IncrementIndex(value != 0 ? steps : 1);
        }

        public void JumpSourceNotZero(char source, int steps)
        {
            var value = _registers[source];
            JumpValueNotZero(value, steps);
        }

        public void Increment(char target)
        {
            _registers[target]++;
            IncrementIndex();
        }

        public void Decrement(char target)
        {
            _registers[target]--;
            IncrementIndex();
        }

        public void Toggle(char target)
        {
            var val = _registers[target];
            var indexToToggle = _index + val;
            if (indexToToggle >= 0 && indexToToggle < _instructions.Length)
            {
                var instructionToToggle = _instructions[indexToToggle];

            }
            IncrementIndex();
        }

/*
For one-argument instructions, inc becomes dec, and all other one-argument instructions become inc.
For two-argument instructions, jnz becomes cpy, and all other two-instructions become jnz.
The arguments of a toggled instruction are not affected.
If an attempt is made to toggle an instruction outside the program, nothing happens.
If toggling produces an invalid instruction (like cpy 1 2) and an attempt is later made to execute that instruction, skip it instead.
If tgl toggles itself (for example, if a is 0, tgl a would target itself and become inc a), the resulting instruction is not executed until the next time it is reached.
*/

        private AssembunnyInstruction ParseInstruction(string s)
        {
            var parts = s.Split(' ');
            var command = parts[0];
            if (command == "cpy")
            {
                var value = parts[1];
                var target = parts[2].First();
                if(int.TryParse(value, out var num))
                    return new SetValueInstruction(this, num, target);
                return new CopyInstruction(this, value.First(), target);
            }

            if (command == "inc")
            {
                var target = parts[1].First();
                return new IncrementInstruction(this, target);
            }

            if (command == "dec")
            {
                var target = parts[1].First();
                return new DecrementInstruction(this, target);
            }

            if (command == "jnz")
            {
                var value = parts[1];
                var steps = int.Parse(parts[2]);
                if (int.TryParse(value, out var num))
                    return new JumpValueNotZeroInstruction(this, num, steps);
                return new JumpSourceNotZeroInstruction(this, value.First(), steps);
            }

            if (command == "tgl")
            {
                var target = parts[1].First();
                return new ToggleInstruction(this, target);
            }

            throw new Exception("Instruction parse error");
        }
    }
}
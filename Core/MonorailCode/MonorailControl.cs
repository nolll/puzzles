using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Core.Tools;

namespace Core.MonorailCode
{
    public class MonorailControl
    {
        private readonly MonorailInstruction[] _instructions;
        private readonly Dictionary<char, int> _registers;
        private int _index;

        public int ValueA => _registers['a'];

        public MonorailControl(string input)
        {
            _instructions = PuzzleInputReader.Read(input).Select(ParseInstruction).ToArray();
            _registers = new Dictionary<char, int> {['a'] = 0, ['b'] = 0, ['c'] = 0, ['d'] = 0};
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

        private MonorailInstruction ParseInstruction(string s)
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

            throw new Exception("Instruction parse error");
        }
    }
}
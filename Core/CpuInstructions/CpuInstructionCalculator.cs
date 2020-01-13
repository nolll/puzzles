using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.CpuInstructions
{
    public class CpuInstructionCalculator
    {
        private readonly Dictionary<string, int> _registers;
        public int LargestValue { get; }

        public CpuInstructionCalculator(string input)
        {
            _registers = new Dictionary<string, int>();
            var instructions = PuzzleInputReader.Read(input);
            
            foreach (var instruction in instructions)
            {
                var parts = instruction.Split(' ');
                var targetRegister = parts[0];
                var change = parts[1] == "inc" ? 1 : -1;
                var value = int.Parse(parts[2]);
                var readRegister = parts[4];
                var condition = parts[5];
                var compareValue = int.Parse(parts[6]);
                
                var currentValue = ReadValue(targetRegister);
                var targetValue = currentValue + change * value;
                
                if(IsConditionTrue(ReadValue(readRegister), condition, compareValue))
                    _registers[targetRegister] = targetValue;
            }

            LargestValue = _registers.Values.Max();
        }

        private int ReadValue(string key)
        {
            if (!_registers.ContainsKey(key))
                _registers.Add(key, 0);

            return _registers[key];
        }

        private bool IsConditionTrue(int a, string condition, int b)
        {
            if (condition == ">")
                return a > b;
            if (condition == "<")
                return a < b;
            if (condition == ">=")
                return a >= b;
            if (condition == "<=")
                return a <= b;
            if (condition == "==")
                return a == b;
            if (condition == "!=")
                return a != b;
            return false;
        }
    }
}
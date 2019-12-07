using System;
using Core.Computer.Instructions;

namespace Core.Computer
{
    public class IntCodeProcess
    {
        private readonly int[] _memory;
        private int _pointer;

        private readonly Action<int> _writeOutputFunc;
        private readonly Func<int> _readInputFunc;

        public IntCodeProcess(int[] memory, Func<int> readInputFunc, Action<int> writeOutputFunc)
        {
            _memory = memory;
            _pointer = 0;
            _readInputFunc = readInputFunc;
            _writeOutputFunc = writeOutputFunc;
        }

        public IntCodeResult Run()
        {
            while (_pointer < _memory.Length)
            {
                var instruction = InstructionParser.Parse(_memory, _pointer);

                if (instruction.Type == InstructionType.Halt)
                    break;

                if (instruction.Type == InstructionType.Addition)
                    PerformAddition(instruction);

                if (instruction.Type == InstructionType.Multiplication)
                    PerformMultiplication(instruction);

                if (instruction.Type == InstructionType.Input)
                    PerformInput(instruction);

                if (instruction.Type == InstructionType.Output)
                    PerformOutput(instruction);

                if (instruction.Type == InstructionType.JumpIfTrue)
                    PerformJumpIfTrue(instruction);

                if (instruction.Type == InstructionType.JumpIfFalse)
                    PerformJumpIfFalse(instruction);

                if (instruction.Type == InstructionType.LessThan)
                    PerformLessThan(instruction);

                if (instruction.Type == InstructionType.Equals)
                    PerformEquals(instruction);
            }

            return new IntCodeResult(_memory);
        }

        private void PerformAddition(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;
            var b = instruction.Parameters[1].Value;
            var target = _memory[_pointer + 3];

            _memory[target] = a + b;
            IncrementPointer(instruction);
        }

        private void PerformMultiplication(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;
            var b = instruction.Parameters[1].Value; 
            var target = _memory[_pointer + 3];

            _memory[target] = a * b;
            IncrementPointer(instruction);
        }

        private void PerformInput(Instruction instruction)
        {
            var input = _readInputFunc();

            var target = instruction.Parameters[0].Value;

            _memory[target] = input;
            IncrementPointer(instruction);
        }

        private void PerformOutput(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;

            _writeOutputFunc(a);
            IncrementPointer(instruction);
        }

        private void PerformJumpIfTrue(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;
            var b = instruction.Parameters[1].Value;

            if (a != 0)
                _pointer = b;
            else
                IncrementPointer(instruction);
        }

        private void PerformJumpIfFalse(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;
            var b = instruction.Parameters[1].Value;

            if (a == 0)
                _pointer = b;
            else
                IncrementPointer(instruction);
        }

        private void PerformLessThan(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;
            var b = instruction.Parameters[1].Value;
            var target = _memory[_pointer + 3];

            _memory[target] = a < b ? 1 : 0;
            IncrementPointer(instruction);
        }

        private void PerformEquals(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;
            var b = instruction.Parameters[1].Value;
            var target = _memory[_pointer + 3];

            _memory[target] = a == b ? 1 : 0;
            IncrementPointer(instruction);
        }

        private void IncrementPointer(Instruction instruction) => _pointer += instruction.Length + 1;
    }
}
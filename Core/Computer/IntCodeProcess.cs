using System;
using System.Collections.Generic;
using Core.Computer.Instructions;

namespace Core.Computer
{
    public class IntCodeProcess
    {
        private readonly IList<long> _memory;
        private int _pointer;
        private int _relativeBase;

        private readonly Action<long> _writeOutputFunc;
        private readonly Func<long> _readInputFunc;
        public IList<long> Memory => _memory;

        public long Result => _memory[0]; 

        public IntCodeProcess(IList<long> memory, Func<long> readInputFunc, Action<long> writeOutputFunc)
        {
            _memory = memory;
            _relativeBase = 0;
            _pointer = 0;
            _readInputFunc = readInputFunc;
            _writeOutputFunc = writeOutputFunc;
        }

        public long Run()
        {
            while (_pointer < _memory.Count)
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

                if (instruction.Type == InstructionType.Relative)
                    PerformRelative(instruction);
            }

            return _memory[0];
        }

        private void PerformAddition(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;
            var b = instruction.Parameters[1].Value;
            var target = _memory[_pointer + 3];

            _memory[(int)target] = a + b;
            IncrementPointer(instruction);
        }

        private void PerformMultiplication(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;
            var b = instruction.Parameters[1].Value; 
            var target = _memory[_pointer + 3];

            _memory[(int)target] = a * b;
            IncrementPointer(instruction);
        }

        private void PerformInput(Instruction instruction)
        {
            var input = _readInputFunc();

            var target = instruction.Parameters[0].Value;

            _memory[(int)target] = input;
            IncrementPointer(instruction);
        }

        private void PerformOutput(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;

            IncrementPointer(instruction);
            _writeOutputFunc(a);
        }

        private void PerformJumpIfTrue(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;
            var b = instruction.Parameters[1].Value;

            if (a != 0)
                _pointer = (int)b;
            else
                IncrementPointer(instruction);
        }

        private void PerformJumpIfFalse(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;
            var b = instruction.Parameters[1].Value;

            if (a == 0)
                _pointer = (int)b;
            else
                IncrementPointer(instruction);
        }

        private void PerformLessThan(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;
            var b = instruction.Parameters[1].Value;
            var target = _memory[_pointer + 3];

            _memory[(int)target] = a < b ? 1 : 0;
            IncrementPointer(instruction);
        }

        private void PerformEquals(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;
            var b = instruction.Parameters[1].Value;
            var target = _memory[_pointer + 3];

            _memory[(int)target] = a == b ? 1 : 0;
            IncrementPointer(instruction);
        }

        private void PerformRelative(Instruction instruction)
        {
            var a = instruction.Parameters[0].Value;

            _relativeBase = (int)a;
            IncrementPointer(instruction);
        }

        private void WriteToMemory(int pos, long val)
        {
            if (pos > _memory.Count - 1)
                IncreaseMemory(pos);
            _memory[pos] = val;
        }

        private void IncreaseMemory(int pos)
        {
            var memLength = _memory.Count;
            for (var i = memLength; i < pos; i++)
            {
                _memory.Add(0);
            }
        }

        private void IncrementPointer(Instruction instruction) => _pointer += instruction.Length + 1;
    }
}
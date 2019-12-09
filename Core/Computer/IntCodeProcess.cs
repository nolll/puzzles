using System;
using System.Collections.Generic;
using Core.Computer.Instructions;
using Core.Computer.Parameters;

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

        public long Result => ReadFromMemory(0); 

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
                var instruction = InstructionParser.Parse(_memory, _pointer, _relativeBase);

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

                if (instruction.Type == InstructionType.AdjustRelativeBase)
                    PerformAdjustRelativeBase(instruction);
            }

            return Result;
        }

        private long ReadParam(Parameter p)
        {
            var storedValue = ReadFromMemory(p.Position);

            if (p.Type == ParameterType.Immediate)
                return storedValue;

            if (p.Type == ParameterType.Position)
                return ReadFromMemory((int)storedValue);

            return ReadFromMemory((int)storedValue + _relativeBase);
        }

        private long ReadTargetPosition(Parameter p)
        {
            var storedValue = p.Position;

            if (p.Type == ParameterType.Relative)
                return ReadFromMemory(storedValue) + _relativeBase;

            return ReadFromMemory(storedValue);
        }

        private void PerformAddition(Instruction instruction)
        {
            var a = ReadParam(instruction.Parameters[0]);
            var b = ReadParam(instruction.Parameters[1]);
            var target = ReadTargetPosition(instruction.Parameters[2]);

            WriteToMemory((int) target, a + b);
            IncrementPointer(instruction);
        }

        private void PerformMultiplication(Instruction instruction)
        {
            var a = ReadParam(instruction.Parameters[0]);
            var b = ReadParam(instruction.Parameters[1]);
            var target = ReadTargetPosition(instruction.Parameters[2]);

            WriteToMemory((int)target, a * b);
            IncrementPointer(instruction);
        }

        private void PerformInput(Instruction instruction)
        {
            var input = _readInputFunc();
            var target = ReadTargetPosition(instruction.Parameters[0]);

            WriteToMemory((int) target, input);
            IncrementPointer(instruction);
        }

        private void PerformOutput(Instruction instruction)
        {
            var a = ReadParam(instruction.Parameters[0]);

            IncrementPointer(instruction);
            _writeOutputFunc(a);
        }

        private void PerformJumpIfTrue(Instruction instruction)
        {
            var a = ReadParam(instruction.Parameters[0]);
            var b = ReadParam(instruction.Parameters[1]);

            if (a != 0)
                _pointer = (int)b;
            else
                IncrementPointer(instruction);
        }

        private void PerformJumpIfFalse(Instruction instruction)
        {
            var a = ReadParam(instruction.Parameters[0]);
            var b = ReadParam(instruction.Parameters[1]);

            if (a == 0)
                _pointer = (int)b;
            else
                IncrementPointer(instruction);
        }

        private void PerformLessThan(Instruction instruction)
        {
            var a = ReadParam(instruction.Parameters[0]);
            var b = ReadParam(instruction.Parameters[1]);
            var target = ReadTargetPosition(instruction.Parameters[2]);

            WriteToMemory((int) target, a < b ? 1 : 0);
            IncrementPointer(instruction);
        }

        private void PerformEquals(Instruction instruction)
        {
            var a = ReadParam(instruction.Parameters[0]);
            var b = ReadParam(instruction.Parameters[1]);
            var target = ReadTargetPosition(instruction.Parameters[2]);

            WriteToMemory((int)target, a == b ? 1 : 0);
            IncrementPointer(instruction);
        }

        private void PerformAdjustRelativeBase(Instruction instruction)
        {
            var a = ReadParam(instruction.Parameters[0]);

            _relativeBase += (int)a;
            IncrementPointer(instruction);
        }

        private long ReadFromMemory(int pos)
        {
            if (pos >= _memory.Count)
                return 0;
            return _memory[pos];
        }

        private void WriteToMemory(int pos, long val)
        {
            if (pos >= _memory.Count)
                IncreaseMemory(pos);
            _memory[pos] = val;
        }

        private void IncreaseMemory(int pos)
        {
            while(pos >= _memory.Count)
            {
                _memory.Add(0);
            }
        }

        private void IncrementPointer(Instruction instruction) => _pointer += instruction.Length + 1;
    }
}
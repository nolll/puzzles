using Pzl.Tools.Computers.IntCode.Instructions;
using Pzl.Tools.Computers.IntCode.Parameters;

namespace Pzl.Tools.Computers.IntCode;

public class IntCodeProcess(IList<long> memory, bool haltAfterInput, Func<long> readInputFunc, Func<long, bool> writeOutputFunc)
{
    private int _pointer;
    private int _relativeBase;

    public IList<long> Memory { get; } = memory;

    private bool _stop;

    public long Result => ReadFromMemory(0);

    public void Stop()
    {
        _stop = true;
    }

    public long Run()
    {
        while (_pointer < Memory.Count)
        {
            var instruction = InstructionParser.Parse(Memory, _pointer, _relativeBase);

            if (_stop || instruction is null || instruction.Type == InstructionType.Halt)
                break;

            if (instruction.Type == InstructionType.Addition)
                PerformAddition(instruction);

            if (instruction.Type == InstructionType.Multiplication)
                PerformMultiplication(instruction);

            if (instruction.Type == InstructionType.Input)
            {
                PerformInput(instruction);
                if (haltAfterInput)
                    break;
            }

            if (instruction.Type == InstructionType.Output)
            {
                var shouldContinue = PerformOutput(instruction);
                if (!shouldContinue)
                    break;
            }

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

        return p.Type switch
        {
            ParameterType.Immediate => storedValue,
            ParameterType.Position => ReadFromMemory((int)storedValue),
            _ => ReadFromMemory((int)storedValue + _relativeBase)
        };
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
        var input = readInputFunc();
        var target = ReadTargetPosition(instruction.Parameters[0]);

        WriteToMemory((int) target, input);
        IncrementPointer(instruction);
    }

    private bool PerformOutput(Instruction instruction)
    {
        var a = ReadParam(instruction.Parameters[0]);

        IncrementPointer(instruction);
        return writeOutputFunc(a);
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
        if (pos >= Memory.Count)
            return 0;
        return Memory[pos];
    }

    private void WriteToMemory(int pos, long val)
    {
        if (pos >= Memory.Count)
            IncreaseMemory(pos);
        Memory[pos] = val;
    }

    private void IncreaseMemory(int pos)
    {
        while(pos >= Memory.Count)
        {
            Memory.Add(0);
        }
    }

    private void IncrementPointer(Instruction instruction) => _pointer += instruction.Length + 1;
}
using Puzzles.Common.Computers.IntCode.Instructions;

namespace Puzzles.Common.Computers.IntCode;

public static class InstructionParser
{
    public static Instruction? Parse(IList<long> memory, int position, int relativeBase)
    {
        if (memory.Count <= position)
            return null;

        var opcode = new Opcode(memory[position]);
        if (opcode.Code == 1)
            return new AdditionInstruction(memory, position, relativeBase, opcode.ParameterTypes);

        if (opcode.Code == 2)
            return new MultiplicationInstruction(memory, position, relativeBase, opcode.ParameterTypes);

        if (opcode.Code == 3)
            return new InputInstruction(memory, position, relativeBase, opcode.ParameterTypes);

        if (opcode.Code == 4)
            return new OutputInstruction(memory, position, relativeBase, opcode.ParameterTypes);

        if (opcode.Code == 5)
            return new JumpIfTrueInstruction(memory, position, relativeBase, opcode.ParameterTypes);

        if (opcode.Code == 6)
            return new JumpIfFalseInstruction(memory, position, relativeBase, opcode.ParameterTypes);

        if (opcode.Code == 7)
            return new LessThanInstruction(memory, position, relativeBase, opcode.ParameterTypes);

        if (opcode.Code == 8)
            return new EqualsInstruction(memory, position, relativeBase, opcode.ParameterTypes);

        if (opcode.Code == 9)
            return new AdjustRelativeBaseInstruction(memory, position, relativeBase, opcode.ParameterTypes);

        if (opcode.Code == 99)
            return new HaltInstruction(memory, position, relativeBase, opcode.ParameterTypes);

        return null;
    }
}
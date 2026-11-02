using Pzl.Tools.Computers.IntCode.Instructions;

namespace Pzl.Tools.Computers.IntCode;

public static class InstructionParser
{
    public static Instruction? Parse(IList<long> memory, int position) => memory.Count > position 
        ? GetInstruction(position, new Opcode(memory[position])) 
        : null;

    private static Instruction? GetInstruction(int position, Opcode opcode) => opcode.Code switch
    {
        1 => new AdditionInstruction(position, opcode.ParameterTypes),
        2 => new MultiplicationInstruction(position, opcode.ParameterTypes),
        3 => new InputInstruction(position, opcode.ParameterTypes),
        4 => new OutputInstruction(position, opcode.ParameterTypes),
        5 => new JumpIfTrueInstruction(position, opcode.ParameterTypes),
        6 => new JumpIfFalseInstruction(position, opcode.ParameterTypes),
        7 => new LessThanInstruction(position, opcode.ParameterTypes),
        8 => new EqualsInstruction(position, opcode.ParameterTypes),
        9 => new AdjustRelativeBaseInstruction(position, opcode.ParameterTypes),
        99 => new HaltInstruction(position, opcode.ParameterTypes),
        _ => null
    };
}
namespace Puzzles.Common.Computers.IntCode.Instructions;

public class JumpIfFalseInstruction : Instruction
{
    public override InstructionType Type => InstructionType.JumpIfFalse;

    public JumpIfFalseInstruction(IList<long> memory, int position, int relativeBase, IList<ParameterType> parameterTypes)
        : base(memory, position, relativeBase, parameterTypes)
    {
        ReadParameter(0);
        ReadParameter(1);
    }
}
namespace Pzl.Tools.Computers.IntCode.Instructions;

public class JumpIfFalseInstruction : Instruction
{
    public override InstructionType Type => InstructionType.JumpIfFalse;

    public JumpIfFalseInstruction(int position, IList<ParameterType> parameterTypes) : base(position, parameterTypes)
    {
        ReadParameter(0);
        ReadParameter(1);
    }
}
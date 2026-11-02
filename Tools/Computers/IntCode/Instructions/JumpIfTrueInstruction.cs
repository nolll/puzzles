namespace Pzl.Tools.Computers.IntCode.Instructions;

public class JumpIfTrueInstruction : Instruction
{
    public override InstructionType Type => InstructionType.JumpIfTrue;

    public JumpIfTrueInstruction(int position, IList<ParameterType> parameterTypes) : base(position, parameterTypes)
    {
        ReadParameter(0);
        ReadParameter(1);
    }
}
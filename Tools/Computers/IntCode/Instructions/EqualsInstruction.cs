namespace Pzl.Tools.Computers.IntCode.Instructions;

public class EqualsInstruction : Instruction
{
    public override InstructionType Type => InstructionType.Equals;

    public EqualsInstruction(int position, IList<ParameterType> parameterTypes) : base(position, parameterTypes)
    {
        ReadParameter(0);
        ReadParameter(1);
        ReadParameter(2);
    }
}
namespace Pzl.Tools.Computers.IntCode.Instructions;

public class LessThanInstruction : Instruction
{
    public override InstructionType Type => InstructionType.LessThan;

    public LessThanInstruction(int position, IList<ParameterType> parameterTypes) : base(position, parameterTypes)
    {
        ReadParameter(0);
        ReadParameter(1);
        ReadParameter(2);
    }
}
namespace Pzl.Tools.Computers.IntCode.Instructions;

public class AdjustRelativeBaseInstruction : Instruction
{
    public override InstructionType Type => InstructionType.AdjustRelativeBase;

    public AdjustRelativeBaseInstruction(int position, IList<ParameterType> parameterTypes) : base(position, parameterTypes)
    {
        ReadParameter(0);
    }
}
namespace Pzl.Tools.Computers.IntCode.Instructions;

public class OutputInstruction : Instruction
{
    public override InstructionType Type => InstructionType.Output;

    public OutputInstruction(int position, IList<ParameterType> parameterTypes) : base(position, parameterTypes)
    {
        ReadParameter(0);
    }
}
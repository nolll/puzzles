namespace Pzl.Tools.Computers.IntCode.Instructions;

public class MultiplicationInstruction : Instruction
{
    public override InstructionType Type => InstructionType.Multiplication;

    public MultiplicationInstruction(int position, IList<ParameterType> parameterTypes) : base(position, parameterTypes)
    {
        ReadParameter(0);
        ReadParameter(1);
        ReadParameter(2);
    }
}
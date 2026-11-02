namespace Pzl.Tools.Computers.IntCode.Instructions;

public class AdditionInstruction : Instruction
{
    public override InstructionType Type => InstructionType.Addition;

    public AdditionInstruction(int position, IList<ParameterType> parameterTypes) : base(position, parameterTypes)
    {
        ReadParameter(0);
        ReadParameter(1);
        ReadParameter(2);
    }
}
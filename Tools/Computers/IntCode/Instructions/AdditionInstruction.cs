namespace Pzl.Tools.Computers.IntCode.Instructions;

public class AdditionInstruction : Instruction
{
    public override InstructionType Type => InstructionType.Addition;

    public AdditionInstruction(IList<long> memory, int position, int relativeBase, IList<ParameterType> parameterTypes)
        : base(memory, position, relativeBase, parameterTypes)
    {
        ReadParameter(0);
        ReadParameter(1);
        ReadParameter(2);
    }
}
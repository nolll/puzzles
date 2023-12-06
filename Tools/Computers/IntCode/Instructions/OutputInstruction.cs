namespace Pzl.Tools.Computers.IntCode.Instructions;

public class OutputInstruction : Instruction
{
    public override InstructionType Type => InstructionType.Output;

    public OutputInstruction(IList<long> memory, int position, int relativeBase, IList<ParameterType> parameterTypes)
        : base(memory, position, relativeBase, parameterTypes)
    {
        ReadParameter(0);
    }
}
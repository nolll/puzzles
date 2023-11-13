namespace Puzzles.common.Computers.IntCode.Instructions;

public class MultiplicationInstruction : Instruction
{
    public override InstructionType Type => InstructionType.Multiplication;

    public MultiplicationInstruction(IList<long> memory, int position, int relativeBase, IList<ParameterType> parameterTypes)
        : base(memory, position, relativeBase, parameterTypes)
    {
        ReadParameter(0);
        ReadParameter(1);
        ReadParameter(2);
    }
}
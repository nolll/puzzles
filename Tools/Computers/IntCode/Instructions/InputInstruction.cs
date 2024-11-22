namespace Pzl.Tools.Computers.IntCode.Instructions;

public class InputInstruction : Instruction
{
    public override InstructionType Type => InstructionType.Input;

    public InputInstruction(IList<long> memory, int position, int relativeBase, IList<ParameterType> parameterTypes)
        : base(memory, position, relativeBase, parameterTypes)
    {
        ReadParameter(0);
    }
}
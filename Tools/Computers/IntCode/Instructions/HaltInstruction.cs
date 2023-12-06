namespace Pzl.Tools.Computers.IntCode.Instructions;

public class HaltInstruction : Instruction
{
    public override InstructionType Type => InstructionType.Halt;

    public HaltInstruction(IList<long> memory, int pointer, int relativeBase, IList<ParameterType> parameterTypes)
        : base(memory, pointer, relativeBase, parameterTypes)
    {
    }
}
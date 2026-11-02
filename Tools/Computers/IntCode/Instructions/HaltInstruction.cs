namespace Pzl.Tools.Computers.IntCode.Instructions;

public class HaltInstruction(IList<long> memory, int pointer, int relativeBase, IList<ParameterType> parameterTypes)
    : Instruction(memory, pointer, relativeBase, parameterTypes)
{
    public override InstructionType Type => InstructionType.Halt;
}
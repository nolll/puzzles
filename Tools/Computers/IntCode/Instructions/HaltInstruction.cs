namespace Pzl.Tools.Computers.IntCode.Instructions;

public class HaltInstruction(int pointer, IList<ParameterType> parameterTypes) : Instruction(pointer, parameterTypes)
{
    public override InstructionType Type => InstructionType.Halt;
}
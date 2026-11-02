namespace Pzl.Tools.Computers.IntCode.Instructions;

public class InputInstruction : Instruction
{
    public override InstructionType Type => InstructionType.Input;

    public InputInstruction(int position, IList<ParameterType> parameterTypes) : base(position, parameterTypes)
    {
        ReadParameter(0);
    }
}
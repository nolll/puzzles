using System.Collections.Generic;

namespace App.Common.Computers.IntCode.Instructions;

public class EqualsInstruction : Instruction
{
    public override InstructionType Type => InstructionType.Equals;

    public EqualsInstruction(IList<long> memory, int position, int relativeBase, IList<ParameterType> parameterTypes)
        : base(memory, position, relativeBase, parameterTypes)
    {
        ReadParameter(0);
        ReadParameter(1);
        ReadParameter(2);
    }
}
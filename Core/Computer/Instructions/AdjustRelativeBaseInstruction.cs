using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class AdjustRelativeBaseInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.AdjustRelativeBase;

        public AdjustRelativeBaseInstruction(IList<long> memory, int position, int relativeBase, IList<ParameterType> parameterTypes)
            : base(memory, position, relativeBase, parameterTypes)
        {
            ReadParameter(0);
        }
    }
}
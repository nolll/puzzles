using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class LessThanInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.LessThan;

        public LessThanInstruction(IList<long> memory, int position, int relativeBase, IList<ParameterType> parameterTypes)
            : base(memory, position, relativeBase, parameterTypes)
        {
            ReadParameter(0);
            ReadParameter(1);
            ReadParameter(2, ParameterType.Position);
        }
    }
}
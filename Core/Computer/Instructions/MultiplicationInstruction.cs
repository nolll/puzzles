using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class MultiplicationInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.Multiplication;

        public MultiplicationInstruction(IList<long> memory, int position, IList<ParameterType> parameterTypes)
            : base(memory, position, parameterTypes)
        {
            ReadParameter(0);
            ReadParameter(1);
            ReadParameter(2, ParameterType.Position);
        }
    }
}
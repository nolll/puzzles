using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class OutputInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.Output;

        public OutputInstruction(IList<long> memory, int position, IList<ParameterType> parameterTypes)
            : base(memory, position, parameterTypes)
        {
            ReadParameter(0);
        }
    }
}
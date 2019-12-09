using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class RelativeInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.Addition;

        public RelativeInstruction(IList<long> memory, int position, IList<ParameterType> parameterTypes)
            : base(memory, position, parameterTypes)
        {
            ReadParameter(0);
        }
    }
}
using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class JumpIfFalseInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.JumpIfFalse;

        public JumpIfFalseInstruction(IList<long> memory, int position, IList<ParameterType> parameterTypes)
            : base(memory, position, parameterTypes)
        {
            ReadParameter(0);
            ReadParameter(1);
        }
    }
}
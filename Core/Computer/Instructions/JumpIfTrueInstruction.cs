using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class JumpIfTrueInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.JumpIfTrue;

        public JumpIfTrueInstruction(int[] memory, int position, IList<ParameterType> parameterTypes)
            : base(memory, position, parameterTypes)
        {
            ReadParameter(0);
            ReadParameter(1);
        }
    }
}
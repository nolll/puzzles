using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class InputInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.Input;

        public InputInstruction(int[] memory, int position, IList<ParameterType> parameterTypes)
            : base(memory, position, parameterTypes)
        {
            ReadParameter(0, ParameterType.Immediate);
        }
    }
}
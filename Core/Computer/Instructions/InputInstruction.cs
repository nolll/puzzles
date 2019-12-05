using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class InputInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.Input;

        public InputInstruction(IList<Parameter> parameters)
            : base(parameters)
        {
        }
    }
}
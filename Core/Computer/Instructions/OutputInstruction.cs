using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class OutputInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.Output;

        public OutputInstruction(IList<Parameter> parameters)
            : base(parameters)
        {
        }
    }
}
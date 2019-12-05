using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class MultiplicationInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.Multiplication;

        public MultiplicationInstruction(IList<Parameter> parameters)
            : base(parameters)
        {
        }
    }
}
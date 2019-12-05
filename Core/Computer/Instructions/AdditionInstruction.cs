using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class AdditionInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.Addition;

        public AdditionInstruction(IList<Parameter> parameters)
            : base(parameters)
        {
        }
    }

    public class JumpIfTrueInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.JumpIfTrue;

        public JumpIfTrueInstruction(IList<Parameter> parameters)
            : base(parameters)
        {
        }
    }

    public class JumpIfFalseInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.JumpIfFalse;

        public JumpIfFalseInstruction(IList<Parameter> parameters)
            : base(parameters)
        {
        }
    }

    public class LessThanInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.LessThan;

        public LessThanInstruction(IList<Parameter> parameters)
            : base(parameters)
        {
        }
    }

    public class EqualsInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.Equals;

        public EqualsInstruction(IList<Parameter> parameters)
            : base(parameters)
        {
        }
    }
}
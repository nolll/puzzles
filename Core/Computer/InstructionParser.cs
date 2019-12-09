using System.Collections.Generic;
using System.Linq;
using Core.Computer.Instructions;

namespace Core.Computer
{
    public static class InstructionParser
    {
        public static Instruction Parse(IList<long> memory, int position = 0)
        {
            if (memory.Count <= position)
                return null;

            var opcode = new Opcode(memory[position]);
            if (opcode.Code == 1)
                return new AdditionInstruction(memory, position, opcode.ParameterTypes);

            if (opcode.Code == 2)
                return new MultiplicationInstruction(memory, position, opcode.ParameterTypes);

            if (opcode.Code == 3)
                return new InputInstruction(memory, position, opcode.ParameterTypes);

            if (opcode.Code == 4)
                return new OutputInstruction(memory, position, opcode.ParameterTypes);

            if (opcode.Code == 5)
                return new JumpIfTrueInstruction(memory, position, opcode.ParameterTypes);

            if (opcode.Code == 6)
                return new JumpIfFalseInstruction(memory, position, opcode.ParameterTypes);

            if (opcode.Code == 7)
                return new LessThanInstruction(memory, position, opcode.ParameterTypes);

            if (opcode.Code == 8)
                return new EqualsInstruction(memory, position, opcode.ParameterTypes);

            if (opcode.Code == 9)
                return new RelativeInstruction(memory, position, opcode.ParameterTypes);

            if (opcode.Code == 99)
                return new HaltInstruction(memory, position, opcode.ParameterTypes);

            return null;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Core.Computer.Instructions;

namespace Core.Computer
{
    public class InstructionParser
    {
        public static Instruction Parse(int[] memory, int position = 0)
        {
            if (memory.Length <= position)
                return null;

            var opcode = new Opcode(memory[position]);
            if (opcode.Code == 1)
                return new AdditionInstruction(CreateParameters(3, opcode.ParameterTypes).ToList());

            if (opcode.Code == 2)
                return new MultiplicationInstruction(CreateParameters(3, opcode.ParameterTypes).ToList());

            if (opcode.Code == 3)
                return new InputInstruction(CreateParameters(1, opcode.ParameterTypes).ToList());

            if (opcode.Code == 4)
                return new OutputInstruction(CreateParameters(1, opcode.ParameterTypes).ToList());

            if (opcode.Code == 5)
                return new JumpIfTrueInstruction(CreateParameters(2, opcode.ParameterTypes).ToList());

            if (opcode.Code == 6)
                return new JumpIfFalseInstruction(CreateParameters(2, opcode.ParameterTypes).ToList());

            if (opcode.Code == 7)
                return new LessThanInstruction(CreateParameters(3, opcode.ParameterTypes).ToList());

            if (opcode.Code == 8)
                return new EqualsInstruction(CreateParameters(3, opcode.ParameterTypes).ToList());

            if (opcode.Code == 99)
                return new HaltInstruction();

            return null;
        }

        private static IEnumerable<Parameter> CreateParameters(int count, IList<ParameterType> types)
        {
            for (var i = 0; i < count; i++)
            {
                yield return CreateParameter(types, i);
            }
        }

        private static Parameter CreateParameter(IList<ParameterType> types, int index)
        {
            if(index >= types.Count)
                return new PositionParameter();

            if (types[index] == ParameterType.Immediate)
                return new ImmediateParameter();
            return new PositionParameter();
        }
    }
}
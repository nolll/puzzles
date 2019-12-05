using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public abstract class Instruction
    {
        public IList<Parameter> Parameters { get; }
        public int Length => Parameters.Count;
        public abstract InstructionType Type { get; }

        protected Instruction(IList<Parameter> parameters = null)
        {
            Parameters = parameters ?? new List<Parameter>();
        }
    }
}
using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public abstract class Instruction
    {
        private readonly int[] _memory;
        private readonly int _pointer;
        private readonly IList<ParameterType> _parameterTypes;
        public IList<Parameter> Parameters { get; }
        public int Length => Parameters.Count;
        public abstract InstructionType Type { get; }

        protected Instruction(int[] memory, int pointer, IList<ParameterType> parameterTypes)
        {
            _memory = memory;
            _pointer = pointer;
            _parameterTypes = parameterTypes;
            Parameters = new List<Parameter>();
        }

        protected void ReadParameter(int parameterIndex, ParameterType? type = null)
        {
            Parameters.Add(CreateParameter(parameterIndex, type));
        }

        private Parameter CreateParameter(int parameterIndex, ParameterType? type = null)
        {
            if (type != null)
                return CreateParameter(parameterIndex, type.Value);

            if (parameterIndex >= _parameterTypes.Count)
                return CreateParameter(parameterIndex, ParameterType.Position);

            return CreateParameter(parameterIndex, _parameterTypes[parameterIndex]);
        }

        private Parameter CreateParameter(int parameterIndex, ParameterType type)
        {
            if (type == ParameterType.Immediate)
                return new ImmediateParameter(_memory, _pointer + 1 + parameterIndex);
            return new PositionParameter(_memory, _pointer + 1 + parameterIndex);
        }
    }
}
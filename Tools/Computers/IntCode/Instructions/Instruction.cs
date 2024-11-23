using Pzl.Tools.Computers.IntCode.Parameters;

namespace Pzl.Tools.Computers.IntCode.Instructions;

public abstract class Instruction
{
    private readonly IList<long> _memory;
    private readonly int _pointer;
    private readonly int _relativeBase;
    private readonly IList<ParameterType> _parameterTypes;
    public IList<Parameter> Parameters { get; }
    public int Length => Parameters.Count;
    public abstract InstructionType Type { get; }

    protected Instruction(IList<long> memory, int pointer, int relativeBase, IList<ParameterType> parameterTypes)
    {
        _memory = memory;
        _pointer = pointer;
        _relativeBase = relativeBase;
        _parameterTypes = parameterTypes;
        Parameters = new List<Parameter>();
    }

    protected void ReadParameter(int parameterIndex)
    {
        Parameters.Add(CreateParameter(parameterIndex));
    }

    private Parameter CreateParameter(int parameterIndex)
    {
        if (parameterIndex >= _parameterTypes.Count)
            return CreateParameter(parameterIndex, ParameterType.Position);

        return CreateParameter(parameterIndex, _parameterTypes[parameterIndex]);
    }

    private Parameter CreateParameter(int parameterIndex, ParameterType type)
    {
        var pos = _pointer + 1 + parameterIndex;
        return type switch
        {
            ParameterType.Relative => new RelativeParameter(pos),
            ParameterType.Immediate => new ImmediateParameter(pos),
            _ => new PositionParameter(pos)
        };
    }
}
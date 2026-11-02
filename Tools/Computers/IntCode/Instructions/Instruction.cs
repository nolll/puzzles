using Pzl.Tools.Computers.IntCode.Parameters;

namespace Pzl.Tools.Computers.IntCode.Instructions;

public abstract class Instruction(IList<long> memory, int pointer, int relativeBase, IList<ParameterType> parameterTypes)
{
    private readonly IList<long> _memory = memory;
    private readonly int _relativeBase = relativeBase;
    public IList<Parameter> Parameters { get; } = new List<Parameter>();
    public int Length => Parameters.Count;
    public abstract InstructionType Type { get; }

    protected void ReadParameter(int parameterIndex)
    {
        Parameters.Add(CreateParameter(parameterIndex));
    }

    private Parameter CreateParameter(int parameterIndex) => CreateParameter(parameterIndex, parameterIndex >= parameterTypes.Count
        ? ParameterType.Position
        : parameterTypes[parameterIndex]);

    private Parameter CreateParameter(int parameterIndex, ParameterType type)
    {
        var pos = pointer + 1 + parameterIndex;
        return type switch
        {
            ParameterType.Relative => new RelativeParameter(pos),
            ParameterType.Immediate => new ImmediateParameter(pos),
            _ => new PositionParameter(pos)
        };
    }
}
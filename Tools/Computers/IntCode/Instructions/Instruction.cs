using Pzl.Tools.Computers.IntCode.Parameters;

namespace Pzl.Tools.Computers.IntCode.Instructions;

public abstract class Instruction(int pointer, IList<ParameterType> parameterTypes)
{
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
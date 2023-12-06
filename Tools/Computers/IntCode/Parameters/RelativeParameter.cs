namespace Pzl.Tools.Computers.IntCode.Parameters;

public class RelativeParameter : Parameter
{
    public RelativeParameter(int pos)
        : base(ParameterType.Relative, pos)
    {
    }
}
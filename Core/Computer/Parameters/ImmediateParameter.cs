namespace Core.Computer.Parameters
{
    public class ImmediateParameter : Parameter
    {
        public ImmediateParameter(int pos)
            : base(ParameterType.Immediate, pos)
        {
        }
    }
}
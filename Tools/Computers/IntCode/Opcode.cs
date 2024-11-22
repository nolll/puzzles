namespace Pzl.Tools.Computers.IntCode;

public class Opcode
{
    public int Code { get; }
    public readonly IList<ParameterType> ParameterTypes;

    public Opcode(long code)
    {
        var str = code.ToString();
        var strOperation = str.Length > 2
            ? str.Substring(str.Length - 2)
            : str;

        if (strOperation.StartsWith("0"))
            strOperation = strOperation.Substring(1);

        Code = int.Parse(strOperation);

        var parameterTypes = new List<ParameterType>();
        if (str.Length > 2)
        {
            str = str.Substring(0, str.Length - 2);
            foreach (var c in str)
            {
                var parameterType = GetParameterType(c);
                parameterTypes.Insert(0, parameterType);
            }
        }

        ParameterTypes = parameterTypes;
    }

    private ParameterType GetParameterType(char c)
    {
        if (c == '2')
            return ParameterType.Relative;

        if (c == '1')
            return ParameterType.Immediate;
            
        return ParameterType.Position;
    }
}

public enum ParameterType
{
    Position,
    Immediate,
    Relative
}
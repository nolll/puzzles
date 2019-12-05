using System.Collections.Generic;

namespace Core.Computer
{
    public class Opcode
    {
        public int Code { get; }
        public IList<ParameterType> ParameterTypes;

        public Opcode(int code)
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
                    var parameterType = c == '1'
                        ? ParameterType.Immediate
                        : ParameterType.Position;

                    parameterTypes.Insert(0, parameterType);
                }
            }

            ParameterTypes = parameterTypes;
        }
    }

    public enum ParameterType
    {
        Position,
        Immediate
    }
}
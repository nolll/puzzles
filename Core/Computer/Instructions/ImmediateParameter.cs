using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class ImmediateParameter : Parameter
    {
        public ImmediateParameter(IList<long> memory, int position)
            : base(ReadFromMemory(memory, position))
        {
        }
    }
}
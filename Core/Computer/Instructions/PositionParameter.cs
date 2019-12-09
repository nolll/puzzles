using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class PositionParameter : Parameter
    {
        public PositionParameter(IList<long> memory, int position)
            : base(memory[(int)memory[position]])
        {
        }
    }
}
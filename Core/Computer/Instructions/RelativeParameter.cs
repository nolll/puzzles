using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class RelativeParameter : Parameter
    {
        public RelativeParameter(IList<long> memory, int position)
            : base(memory[position])
        {
        }
    }
}
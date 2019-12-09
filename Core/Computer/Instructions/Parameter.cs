using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public abstract class Parameter
    {
        public long Value { get; }

        protected Parameter(long value)
        {
            Value = value;
        }

        protected static long ReadFromMemory(IList<long> memory, int pos)
        {
            if (pos >= memory.Count)
                return 0;
            return memory[pos];
        }
    }
}
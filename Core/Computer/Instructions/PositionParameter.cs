using System.Collections.Generic;

namespace Core.Computer.Instructions
{
    public class PositionParameter : Parameter
    {
        public PositionParameter(IList<long> memory, int position)
            : base(ReadPosition(memory, position))
        {
        }

        private static long ReadPosition(IList<long> memory, int position)
        {
            var positionFromMemory = (int) ReadFromMemory(memory, position);
            return ReadFromMemory(memory, positionFromMemory);
        }
    }
}
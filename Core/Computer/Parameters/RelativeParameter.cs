using System.Collections.Generic;

namespace Core.Computer.Parameters
{
    public class RelativeParameter : Parameter
    {
        public RelativeParameter(IList<long> memory, int position, int relativeBase)
            : base(ReadRelativePosition(memory, position, relativeBase))
        {
        }

        private static long ReadRelativePosition(IList<long> memory, int position, int relativeBase)
        {
            var positionFromMemory = (int)ReadFromMemory(memory, position);
            var adjustedPosition = positionFromMemory + relativeBase;
            return ReadFromMemory(memory, adjustedPosition);
        }
    }
}
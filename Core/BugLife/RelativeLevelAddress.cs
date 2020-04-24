using Core.Tools;

namespace Core.BugLife
{
    public class RelativeLevelAddress
    {
        public int RelativeLevel { get; }
        public MatrixAddress Address { get; }

        public RelativeLevelAddress(int relativeLevel, MatrixAddress address)
        {
            RelativeLevel = relativeLevel;
            Address = address;
        }
    }
}
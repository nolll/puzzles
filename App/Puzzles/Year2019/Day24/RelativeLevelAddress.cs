using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2019.Day24
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
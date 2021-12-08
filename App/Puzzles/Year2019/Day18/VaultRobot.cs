using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2019.Day18
{
    public class VaultRobot
    {
        public MatrixAddress Address { get; }

        public VaultRobot(MatrixAddress address)
        {
            Address = address;
        }
    }
}
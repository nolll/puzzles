using Core.Common.CoordinateSystems;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2019.Day18;

public class VaultRobot
{
    public MatrixAddress Address { get; }

    public VaultRobot(MatrixAddress address)
    {
        Address = address;
    }
}
using Core.Common.CoordinateSystems;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2016.Day24;

public class AirDuctRobot
{
    public MatrixAddress Address { get; }

    public AirDuctRobot(MatrixAddress address)
    {
        Address = address;
    }
}
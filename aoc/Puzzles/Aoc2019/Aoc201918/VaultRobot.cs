using Common.CoordinateSystems.CoordinateSystem2D;

namespace Aoc.Puzzles.Aoc2019.Day18;

public class VaultRobot
{
    public MatrixAddress Address { get; }

    public VaultRobot(MatrixAddress address)
    {
        Address = address;
    }
}
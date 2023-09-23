using Common.CoordinateSystems.CoordinateSystem2D;

namespace Aoc.Puzzles.Year2019.Day20;

public class DonutPortalAddress
{
    public string Name { get; }
    public MatrixAddress Address { get; }

    public DonutPortalAddress(string name, MatrixAddress address)
    {
        Name = name;
        Address = address;
    }
}
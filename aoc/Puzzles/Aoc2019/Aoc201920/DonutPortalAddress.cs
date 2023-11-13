using Puzzles.common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201920;

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
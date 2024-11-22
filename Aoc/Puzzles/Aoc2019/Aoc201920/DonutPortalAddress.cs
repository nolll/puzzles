using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201920;

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
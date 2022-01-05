using Core.Common.CoordinateSystems;

namespace Core.Puzzles.Year2016.Day24;

public class AirDuctLocation
{
    public char Id { get; }
    public MatrixAddress Address { get; }

    public AirDuctLocation(char id, MatrixAddress address)
    {
        Id = id;
        Address = address;
    }
}
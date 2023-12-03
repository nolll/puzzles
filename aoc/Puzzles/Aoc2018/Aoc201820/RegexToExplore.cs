using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201820;

public class RegexToExplore
{
    public MatrixAddress StartAddress { get; }
    public string Path { get; }

    public RegexToExplore(MatrixAddress startAddress, string path)
    {
        StartAddress = startAddress;
        Path = path;
    }
}
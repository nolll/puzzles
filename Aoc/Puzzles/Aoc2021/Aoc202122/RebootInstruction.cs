using Pzl.Tools.Grids.Grids3d;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202122;

public class RebootInstruction
{
    public string Mode { get; }
    public Coord3d From { get; }
    public Coord3d To { get; }

    public RebootInstruction(string mode, Coord3d from, Coord3d to)
    {
        Mode = mode;
        From = from;
        To = to;
    }
}
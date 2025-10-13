using Pzl.Tools.Grids.Grids3d;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202122;

public class RebootInstruction
{
    public string Mode { get; }
    public Matrix3DAddress From { get; }
    public Matrix3DAddress To { get; }

    public RebootInstruction(string mode, Matrix3DAddress from, Matrix3DAddress to)
    {
        Mode = mode;
        From = from;
        To = to;
    }
}
namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201713;

public class FirewallLayer
{
    public int Range { get; }

    public FirewallLayer(int range = 0)
    {
        Range = range < 2 ? 0 : range;
    }

    public bool IsCaught(in int iteration)
    {
        if (Range == 0)
            return false;
        if (iteration == 0)
            return true;
        if (iteration < Range)
            return iteration == 0;

        return iteration % (2 * (Range - 1)) == 0;
    }
}
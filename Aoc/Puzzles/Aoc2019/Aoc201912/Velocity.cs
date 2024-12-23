namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201912;

public class Velocity
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    public int KineticEnergy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);

    public Velocity(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
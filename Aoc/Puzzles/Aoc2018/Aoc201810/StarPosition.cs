namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201810;

public class StarPosition
{
    private readonly int _vx;
    private readonly int _vy;

    public int X { get; private set; }
    public int Y { get; private set; }

    public StarPosition(int x, int y, int vx, int vy)
    {
        _vx = vx;
        _vy = vy;
        X = x;
        Y = y;
    }

    public void Move()
    {
        X += _vx;
        Y += _vy;
    }
}
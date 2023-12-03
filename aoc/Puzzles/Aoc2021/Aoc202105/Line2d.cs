namespace Puzzles.Aoc.Puzzles.Aoc2021.Aoc202105;

public class Line2d
{
    public Position2d Start { get; }
    public Position2d End { get; }
    public List<Position2d> Positions { get; }
    public bool IsPerpendicular { get; }

    public Line2d(Position2d a, Position2d b)
    {
        var list = new List<Position2d> { a, b };
        list = list.OrderBy(o => o.X).ThenBy(o => o.Y).ToList();

        Start = list.First();
        End = list.Last();

        var isHorizontal = a.Y == b.Y;
        var isVertical = a.X == b.X;
        IsPerpendicular = isHorizontal || isVertical;

        Positions = GetPositions().ToList();
    }

    private IEnumerable<Position2d> GetPositions()
    {
        var x = Start.X;
        var y = Start.Y;
        var xDiff = End.X - Start.X;
        var yDiff = End.Y - Start.Y;
        var xDelta = xDiff != 0 ? xDiff / Math.Abs(xDiff) : 0;
        var yDelta = yDiff != 0 ? yDiff / Math.Abs(yDiff) : 0;
        var xMin = Math.Min(Start.X, End.X);
        var yMin = Math.Min(Start.Y, End.Y);
        var xMax = Math.Max(Start.X, End.X);
        var yMax = Math.Max(Start.Y, End.Y);

        if (xDiff == 0 && yDiff == 0)
            yield return new Position2d(Start.X, Start.Y);

        while (x >= xMin && x <= xMax && y >= yMin && y <= yMax)
        {
            yield return new Position2d(x, y);
            x += xDelta;
            y += yDelta;
        }
    }
}
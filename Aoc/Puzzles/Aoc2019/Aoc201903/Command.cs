namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201903;

public abstract class Command
{
    private readonly int _distance;

    protected Command(int distance)
    {
        _distance = distance;
    }

    protected abstract Point Move(Point lastPoint);

    public IList<Point> Execute(Point fromPoint)
    {
        var points = new List<Point>();
        var lastPoint = fromPoint;
        for (var i = 1; i <= _distance; i++)
        {
            var point = Move(lastPoint);
            points.Add(point);
            lastPoint = point;
        }
        return points;
    }
}
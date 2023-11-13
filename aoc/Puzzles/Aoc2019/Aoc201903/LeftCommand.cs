namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201903;

public class LeftCommand : Command
{
    public LeftCommand(int distance)
        : base(distance)
    {
    }

    protected override Point Move(Point lastPoint)
    {
        return new Point(lastPoint.X - 1, lastPoint.Y, lastPoint.Steps + 1);
    }
}
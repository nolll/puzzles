using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.CoordinateSystems.CoordinateSystem3D;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202322;

[Name("Sand Slabs")]
public class Aoc202322(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        return PuzzleResult.Empty;
    }

    protected override PuzzleResult RunPart2()
    {
        return PuzzleResult.Empty;
    }

    public static int DisintegrateBricks(string s)
    {
        var bricks = StringReader.ReadLines(s).Select(ParseBrick).OrderBy(o => o.From.Z).ToList();

        var lastBrick = bricks.First();
        lastBrick.MoveTo(1);
        foreach (var brick in bricks.Skip(1))
        {
            brick.MoveTo(1);
            while (brick.IsOverlapping(lastBrick))
            {
                brick.MoveUp();
            }

            lastBrick = brick;
        }

        var bricksThatCanBeRemoved = new List<Brick>();
        foreach (var removedBrick in bricks)
        {
            var canBeRemoved = true;
            foreach (var checkedBrick in bricks)
            {
                if(checkedBrick.Id == removedBrick.Id)
                    continue;

                checkedBrick.MoveDown();
                var isColliding = bricks.Any(o => o.IsOverlapping(checkedBrick));
                if (!isColliding)
                {
                    canBeRemoved = false;
                    break;
                }

                checkedBrick.MoveUp();
            }

            if(canBeRemoved)
                bricksThatCanBeRemoved.Add(removedBrick);
        }

        return bricksThatCanBeRemoved.Count;
    }

    private static Brick ParseBrick(string s, int index)
    {
        var parts = s.Split('~');
        var from = ParseAddress(parts[0]);
        var to = ParseAddress(parts[1]);
        return new Brick(index, from, to);
    }

    private static Matrix3DAddress ParseAddress(string s)
    {
        var parts = s.Split(',').Select(int.Parse).ToArray();
        return new Matrix3DAddress(parts[0], parts[1], parts[2]);
    }
}

internal class Brick
{
    public int Id { get; }
    public Matrix3DAddress From { get; private set; }
    public Matrix3DAddress To { get; private set; }

    public Brick(int id, Matrix3DAddress from, Matrix3DAddress to)
    {
        Id = id;
        From = from;
        To = to;
    }

    public bool IsOverlapping(Brick other) =>
        IsOverlapping(From.X, To.X, other.From.X, other.To.X) &&
        IsOverlapping(From.Y, To.Y, other.From.Y, other.To.Y) &&
        IsOverlapping(From.Z, To.Z, other.From.Z, other.To.Z);

    public void MoveUp() => MoveTo(From.Z + 1);
    public void MoveDown() => MoveTo(From.Z - 1);

    public void MoveTo(int zBottom)
    {
        var diff = To.Z - From.Z;
        From = new Matrix3DAddress(From.X, From.Y, zBottom + diff);
        To = new Matrix3DAddress(To.X, To.Y, zBottom);
    }

    private static bool IsOverlapping(int fromA, int toA, int fromB, int toB)
        => (fromA <= toB && toA >= fromB);
}
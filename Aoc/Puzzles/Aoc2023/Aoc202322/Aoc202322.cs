using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem3D;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202322;

[Name("Sand Slabs")]
public class Aoc202322(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        return new PuzzleResult(DisintegrateBricks(input), "1365c818d49ae8af1974dc302f134abb");
    }

    protected override PuzzleResult RunPart2()
    {
        return PuzzleResult.Empty;
    }

    public static int DisintegrateBricks(string s)
    {
        var bricks = StringReader.ReadLines(s).Select(ParseBrick).OrderBy(o => o.Bottom.Z).ToList();

        bricks = MoveDownAsFarAsPossible(bricks);

        var bricksThatCanBeRemoved = new List<Brick>();
        foreach (var removedBrick in bricks)
        {
            var touchingBricks = CloneBricks(bricks.Where(o => o.Bottom.Z == removedBrick.Top.Z + 1).ToList());
            var blockingBricks = bricks.Where(o => o.Top.Z == removedBrick.Top.Z && removedBrick.Id != o.Id).ToList();

            var unsupportedBricks = 0;
            foreach (var touchingBrick in touchingBricks)
            {
                touchingBrick.MoveDown();
                var hasSupport = touchingBrick.Bottom.Z == 0 || blockingBricks.Any(o => o.IsOverlapping(touchingBrick));
                if (!hasSupport)
                {
                    unsupportedBricks++;
                }
            }

            if (unsupportedBricks == 0)
                bricksThatCanBeRemoved.Add(removedBrick);
        }

        return bricksThatCanBeRemoved.Count;
    }

    private static List<Brick> MoveDownAsFarAsPossible(List<Brick> bricks)
    {
        bricks = CloneBricks(bricks);
        var settledBricks = new List<Brick>();
        foreach (var brick in bricks)
        {
            while (brick.Bottom.Z > 1)
            {
                brick.MoveDown();
                var blockingBricks = settledBricks.Where(o => o.Top.Z == brick.Bottom.Z).ToList();
                var isOverlapping = blockingBricks.Any(o => o.IsOverlapping(brick));
                if (isOverlapping)
                {
                    brick.MoveUp();
                    break;
                }
            }

            settledBricks.Add(brick);
        }

        return settledBricks;
    }

    private static List<Brick> CloneBricks(List<Brick> bricks) => bricks.Select(CloneBrick).ToList();
    private static Brick CloneBrick(Brick brick) => new(brick.Id, brick.Bottom, brick.Top);

    private static Brick ParseBrick(string s, int index)
    {
        var parts = s.Split('~');
        var bottom = ParseAddress(parts[0]);
        var top = ParseAddress(parts[1]);
        return new Brick(index, bottom, top);
    }

    private static Matrix3DAddress ParseAddress(string s)
    {
        var parts = s.Split(',').Select(int.Parse).ToArray();
        return new Matrix3DAddress(parts[0], parts[1], parts[2]);
    }
}
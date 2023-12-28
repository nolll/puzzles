using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem3D;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202322;

[Name("Sand Slabs")]
public class Aoc202322(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        return new PuzzleResult(CountBricksThatCanBeRemoved(input), "1365c818d49ae8af1974dc302f134abb");
    }

    protected override PuzzleResult RunPart2()
    {
        return new PuzzleResult(CountTotalRemovedBricks(input), "81d92f2381d8798f847dd6eb9e0ea6b2");
    }

    public static int CountBricksThatCanBeRemoved(string s)
    {
        var bricks = GetBricksWithInfo(GetSettledBricks(s));
        var bricksThatCanBeRemoved = bricks.Where(o => o.CanBeRemoved);
        return bricksThatCanBeRemoved.Count();
    }

    public static int CountTotalRemovedBricks(string s)
    {
        var bricks = GetBricksWithInfo(GetSettledBricks(s));
        var dict = bricks.ToDictionary(k => k.Id, v => v);

        var totalRemoved = 0;
        foreach (var removedBrick in bricks.Where(o => !o.CanBeRemoved))
        {
            var queue = new Queue<int>();
            var removed = new HashSet<int> { removedBrick.Id };
            foreach (var supporting in removedBrick.Supporting)
            {
                queue.Enqueue(supporting);
            }

            while (queue.Count > 0)
            {
                var id = queue.Dequeue();
                var brick = dict[id];
                if (brick.SupportedBy.All(removed.Contains))
                {
                    removed.Add(id);

                    foreach (var supportedBrick in brick.Supporting)
                    {
                        queue.Enqueue(supportedBrick);
                    }
                }
            }

            totalRemoved += removed.Count - 1;
        }

        return totalRemoved;
    }

    private static List<Brick> GetSettledBricks(string s)
    {
        var bricks = StringReader.ReadLines(s).Select(ParseBrick).OrderBy(o => o.Bottom.Z).ToList();

        return MoveDownAsFarAsPossible(bricks).OrderBy(o => o.Bottom.Z).ToList();
    }

    private static List<Brick> GetBricksWithInfo(List<Brick> bricks)
    {
        foreach (var currentBrick in bricks)
        {
            var bricksThatCouldBeRestingOnCurrentBrick = bricks.Where(o => o.Bottom.Z == currentBrick.Top.Z + 1);
            var otherBricksWithSameTopLevel = bricks
                .Where(o => o.Top.Z == currentBrick.Top.Z)
                .Where(o => currentBrick.Id != o.Id).ToList();

            var bricksOnlySupportedByCurrentBrick = new List<int>();
            foreach (var brickThatCouldBeRestingOnCurrentBlock in bricksThatCouldBeRestingOnCurrentBrick)
            {
                var hasOtherSupport = otherBricksWithSameTopLevel.Any(o => o.IsSupporting(brickThatCouldBeRestingOnCurrentBlock));
                if (!hasOtherSupport)
                {
                    bricksOnlySupportedByCurrentBrick.Add(brickThatCouldBeRestingOnCurrentBlock.Id);
                }

                if (currentBrick.IsSupporting(brickThatCouldBeRestingOnCurrentBlock))
                {
                    currentBrick.Supporting.Add(brickThatCouldBeRestingOnCurrentBlock.Id);
                    brickThatCouldBeRestingOnCurrentBlock.SupportedBy.Add(currentBrick.Id);
                }
            }

            currentBrick.CanBeRemoved = bricksOnlySupportedByCurrentBrick.Count == 0;
        }

        return bricks;
    }

    private static List<Brick> MoveDownAsFarAsPossible(List<Brick> bricks)
    {
        var settledBricks = new List<Brick>();
        foreach (var brick in bricks)
        {
            while (brick.Bottom.Z > 1)
            {
                var blockingBricks = settledBricks.Where(o => o.Top.Z == brick.Bottom.Z - 1).ToList();
                var isSettled = blockingBricks.Any(o => o.IsSupporting(brick));
                if (isSettled)
                    break;

                brick.MoveDown();
            }

            settledBricks.Add(brick);
        }

        return settledBricks;
    }

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
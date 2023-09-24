using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Aoc2021.Day17;

public class TrickShot
{
    public TrickshotResult Shoot(TrickshotTarget target)
    {
        var count = 0;
        var heights = new HashSet<int>();
        for (var vyStart = target.VyMin; vyStart <= target.VyMax; vyStart++)
        {
            for (var vxStart = target.VxMin; vxStart <= target.VxMax; vxStart++)
            {
                var maxHeight = GetMaxHeight(target, vxStart, vyStart);

                if (maxHeight != null)
                {
                    count++;

                    if (!heights.Contains(maxHeight.Value))
                        heights.Add(maxHeight.Value);
                }
            }
        }

        if (heights.Any())
            return new TrickshotResult(heights.Max(), count);

        return new TrickshotResult(0, 0);
    }

    public int? GetMaxHeight(TrickshotTarget target, int vxStart, int vyStart)
    {
        var x = 0;
        var y = 0;

        var vx = vxStart;
        var vy = vyStart;

        var yMax = int.MinValue;
        var hitTarget = false;
        while (y > target.YMin && x < target.XMax)
        {
            x += vx;
            y += vy;
            if (vx > 0)
                vx -= 1;
            else if (x < 0)
                vx += 1;
            vy--;

            var isOnTarget = IsOnTarget(target, x, y);
            if (isOnTarget)
                hitTarget = true;

            if (y > yMax)
                yMax = y;
        }

        return hitTarget ? yMax : null;
    }

    private bool IsOnTarget(TrickshotTarget target, int x, int y)
    {
        if (x < target.XMin)
            return false;
        if (x > target.XMax)
            return false;
        if (y < target.YMin)
            return false;
        if (y > target.YMax)
            return false;

        return true;
    }
}
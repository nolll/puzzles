using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Trick Shot")]
public class Aoc202117 : AocPuzzle
{
    private TrickshotResult? _result;

    [Puzzle("375d1d4838312873a7516c061904317c")]
    public int Part1(string input) => Shoot().MaxHeight;

    [Puzzle("25eea3cce163ac31e5c10a5df5210cee")]
    public int Part2(string input) => Shoot().HitCount;

    private TrickshotResult Shoot() => _result ??= new TrickShot().Shoot(new TrickshotTarget(81, 129, -150, -108));
    
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
    
    public class TrickshotResult
    {
        public int MaxHeight { get; }
        public int HitCount { get; }

        public TrickshotResult(int maxHeight, int hitCount)
        {
            MaxHeight = maxHeight;
            HitCount = hitCount;
        }
    }
    
    public class TrickshotTarget
    {
        public int XMin { get; }
        public int XMax { get; }
        public int YMin { get; }
        public int YMax { get; }

        public int VxMin { get; }
        public int VxMax { get; }
        public int VyMin { get; }
        public int VyMax { get; }

        public TrickshotTarget(int xMin, int xMax, int yMin, int yMax)
        {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
            
            VxMax = Math.Max(Math.Abs(xMin), Math.Abs(xMax));
            VxMin = -VxMax;

            VyMax = Math.Max(Math.Abs(yMin), Math.Abs(yMax));
            VyMin = -VyMax;
        }
    }
}
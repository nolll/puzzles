using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace App.Puzzles.Year2021.Day17
{
    public class Year2021Day17Tests
    {
        [Test]
        public void Part1()
        {
            var target = new TrickshotTarget(20, 30, -10, -5);

            var trickshot = new TrickShot();
            var result = trickshot.GetMaxHeight(target);

            Assert.That(result, Is.EqualTo(45));
        }

        [Test]
        public void SingleMaxHeight()
        {
            var target = new TrickshotTarget(20, 30, -10, -5);

            var trickshot = new TrickShot();
            var result = trickshot.GetMaxHeight(target, 6, 9);

            Assert.That(result, Is.EqualTo(45));
        }

        [Test]
        public void Part2()
        {
            var result = 0;

            Assert.That(result, Is.EqualTo(0));
        }

        private const string Input = @"
";
    }

    public class TrickshotTarget
    {
        public int XMin { get; }
        public int XMax { get; }
        public int YMin { get; }
        public int YMax { get; }

        public TrickshotTarget(int XMin, int xMax, int yMin, int yMax)
        {
            this.XMin = XMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
        }
    }

    public class TrickshotVelocity
    {
        public int Vx { get; }
        public int Vy { get; }

        public TrickshotVelocity(int vx, int vy)
        {
            Vx = vx;
            Vy = vy;
        }
    }

    public class TrickShot
    {
        public int GetMaxHeight(TrickshotTarget target)
        {
            var heights = new HashSet<int>();
            for (var vyStart = 1; vyStart < 300; vyStart++)
            {
                for (var vxStart = 0; vxStart < 100; vxStart++)
                {
                    var maxHeight = GetMaxHeight(target, vxStart, vyStart);

                    if(maxHeight != null && !heights.Contains(maxHeight.Value))
                        heights.Add(maxHeight.Value);
                }
            }
            
            return heights.Max();
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
}
using System;
using System.Collections.Generic;

namespace Core.ExperimentalEmergencyTeleportation
{
    public class SpaceBox
    {
        public Point3d Min { get; }
        public Point3d Max { get; }

        public int SizeX => Max.X - Min.X;
        public int SizeY => Max.Y - Min.Y;
        public int SizeZ => Max.Z - Min.Z;
        public int SmallestSize => Math.Min(SizeX, Math.Min(SizeY, SizeZ));

        public SpaceBox(Point3d min, Point3d max)
        {
            Min = min;
            Max = max;
        }

        public IEnumerable<SpaceBox> Divide()
        {
            var xSize = Max.X - Min.X + 1;
            var ySize = Max.Y - Min.Y + 1;
            var zSize = Max.Z - Min.Z + 1;
            var xMid = Min.X + xSize / 2;
            var yMid = Min.Y + ySize / 2;
            var zMid = Min.Z + zSize / 2;
            
            yield return new SpaceBox(new Point3d(Min.X, Min.Y, Min.Z), new Point3d(xMid - 1, yMid - 1, zMid - 1));
            yield return new SpaceBox(new Point3d(xMid, Min.Y, Min.Z), new Point3d(Max.X, yMid - 1, zMid - 1));
            yield return new SpaceBox(new Point3d(Min.X, yMid, Min.Z), new Point3d(xMid - 1, Max.Y, zMid - 1));
            yield return new SpaceBox(new Point3d(Min.X, Min.Y, zMid), new Point3d(xMid - 1, yMid - 1, Max.Z));
            yield return new SpaceBox(new Point3d(xMid, yMid, Min.Z), new Point3d(Max.X, Max.Y, zMid - 1));
            yield return new SpaceBox(new Point3d(xMid, Min.Y, zMid), new Point3d(Max.X, yMid - 1, Max.Z));
            yield return new SpaceBox(new Point3d(Min.X, yMid, zMid), new Point3d(xMid - 1, Max.Y, Max.Z));
            yield return new SpaceBox(new Point3d(xMid, yMid, zMid), new Point3d(Max.X, Max.Y, Max.Z));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class FourDimensionalAdventureTests
    {
        [Test]
        public void FindsConstellations1()
        {
            const string input = @"
 0,0,0,0
 3,0,0,0
 0,3,0,0
 0,0,3,0
 0,0,0,3
 0,0,0,6
 9,0,0,0
12,0,0,0";

            var finder = new ConstellationFinder(input);
            var constellationCount = finder.Find();
        }
    }

    public class ConstellationFinder
    {
        public ConstellationFinder(string input)
        {
            var points = ParsePoints(input);
        }

        private IList<Point4d> ParsePoints(string input)
        {
            var rows = PuzzleInputReader.Read(input);
            return rows.Select(ParsePoint).ToList();
        }

        private Point4d ParsePoint(string s)
        {
            var coords = s.Trim().Split(',').Select(int.Parse).ToList();
            return new Point4d(coords[0], coords[1], coords[2], coords[3]);
        }

        public int Find()
        {
            return 0;
        }
    }

    public class Point4d
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }
        public int W { get; }

        public Point4d(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public int ManhattanDistanceTo(Point4d other) => ManhattanDistanceTo(other.X, other.Y, other.Z, other.W);
        private int ManhattanDistanceTo(int x, int y, int z, int w) => GetDistance(X, x) + GetDistance(Y, y) + GetDistance(Z, z) + GetDistance(W, w);
        private int GetDistance(int a, int b) => Math.Max(a, b) - Math.Min(a, b);
    }
}
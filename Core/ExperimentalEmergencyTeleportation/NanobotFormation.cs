using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.ExperimentalEmergencyTeleportation
{
    public class NanobotFormation
    {
        private readonly Point3d _origo = new Point3d(0, 0, 0);
        private readonly IList<Nanobot> _bots;

        public NanobotFormation(string input)
        {
            _bots = ParseBots(input);
        }

        public int FindManhattanDistanceToBestCoords()
        {
            var maxRadius = _bots.Max(o => o.SignalRadius);
            var padding = maxRadius + 100000;

            var xMin = _bots.Min(o => o.Coords.X) - padding;
            var xMax = _bots.Max(o => o.Coords.X) + padding;
            var yMin = _bots.Min(o => o.Coords.Y) - padding;
            var yMax = _bots.Max(o => o.Coords.Y) + padding;
            var zMin = _bots.Min(o => o.Coords.Z) - padding;
            var zMax = _bots.Max(o => o.Coords.Z) + padding;
            
            var rootBox = new SpaceBox(new Point3d(xMin, yMin, zMin), new Point3d(xMax, yMax, zMax));
            var bestBox = FindBestCoords(rootBox);

            var bestCoords = FindBestCoordsInBestBox(bestBox);

            return bestCoords.Min(o => o.ManhattanDistanceTo(_origo));
        }

        private IList<Point3d> FindBestCoordsInBestBox(SpaceBox box)
        {
            var iterations = 0;
            var mostBots = 0;
            var bestCoords = new List<Point3d>();

            for (var x = box.Min.X; x <= box.Max.X; x++)
            {
                for (var y = box.Min.Y; y <= box.Max.Y; y++)
                {
                    for (var z = box.Min.Z; z <= box.Max.Z; z++)
                    {
                        var botCount = _bots.Count(o => o.IsInRange(x, y, z));
                        if (botCount > mostBots)
                        {
                            mostBots = botCount;
                            bestCoords = new List<Point3d> { new Point3d(x, y, z) };
                        }
                        else if (botCount == mostBots)
                        {
                            bestCoords.Add(new Point3d(x, y, z));
                        }

                        iterations++;
                    }
                }
            }

            return bestCoords;
        }

        private SpaceBox FindBestCoords(SpaceBox box)
        {
            //var priorityQueue
            var subBoxes = DivideBox(box).ToList();
            var subBoxesWithBotCounts = subBoxes.Select(CountBotsInRange).ToList();
            var bestCount = subBoxesWithBotCounts.Max(o => o.count);
            var bestBoxes = subBoxesWithBotCounts.Where(o => o.count == bestCount).Select(o => o.box).ToList();
            var bestBoxesWithDistances = bestBoxes.Select(o => (o, ManhattanDistanceTo(_origo, o))).ToList();
            var bestBox = bestBoxesWithDistances.OrderBy(o => o.Item2).First().o;
            if (bestBox.SmallestSize <= 10)
                return bestBox;
            return FindBestCoords(bestBox);
        }

        private (SpaceBox box, int count) CountBotsInRange(SpaceBox spaceBox)
        {
            return (spaceBox, _bots.Count(o => IsInRange(o, spaceBox)));
        }

        private int ManhattanDistanceTo(Point3d point, SpaceBox box)
        {
            var closestPoint = GetClosestPoint(point, box);
            return point.ManhattanDistanceTo(closestPoint);
        }

        private bool IsInRange(Nanobot bot, SpaceBox box)
        {
            var distance = ManhattanDistanceTo(bot.Coords, box);
            return distance <= bot.SignalRadius;
        }

        private bool IsInRange2(Nanobot bot, SpaceBox box)
        {
            var dist1 = bot.Coords.ManhattanDistanceTo(box.Max.X, box.Max.Y, box.Max.Z);
            var dist2 = bot.Coords.ManhattanDistanceTo(box.Max.X, box.Max.Y, box.Min.Z);
            var dist3 = bot.Coords.ManhattanDistanceTo(box.Max.X, box.Min.Y, box.Max.Z);
            var dist4 = bot.Coords.ManhattanDistanceTo(box.Max.X, box.Min.Y, box.Min.Z);

            var dist5 = bot.Coords.ManhattanDistanceTo(box.Min.X, box.Max.Y, box.Max.Z);
            var dist6 = bot.Coords.ManhattanDistanceTo(box.Min.X, box.Max.Y, box.Min.Z);
            
            var dist7 = bot.Coords.ManhattanDistanceTo(box.Min.X, box.Min.Y, box.Max.Z);
            
            var dist8 = bot.Coords.ManhattanDistanceTo(box.Min.X, box.Min.Y, box.Min.Z);

            return dist1 <= bot.SignalRadius &&
                   dist2 <= bot.SignalRadius &&
                   dist3 <= bot.SignalRadius &&
                   dist4 <= bot.SignalRadius &&
                   dist5 <= bot.SignalRadius &&
                   dist6 <= bot.SignalRadius &&
                   dist7 <= bot.SignalRadius &&
                   dist8 <= bot.SignalRadius;
        }

        private Point3d GetClosestPoint(Point3d point, SpaceBox box)
        {
            var x = point.X;
            var y = point.Y;
            var z = point.Z;

            if (x < box.Min.X)
                x = box.Min.X;
            else if (x > box.Max.X)
                x = box.Max.X;

            if (y < box.Min.Y)
                y = box.Min.Y;
            else if (y > box.Max.Y)
                y = box.Max.Y;

            if (z < box.Min.Z)
                z = box.Min.Z;
            else if (z > box.Max.Z)
                z = box.Max.Z;
            return new Point3d(x, y, z);
        }

        private IEnumerable<SpaceBox> DivideBox(SpaceBox box)
        {
            return box.Divide();
        }

        private Nanobot FindStrongestBot()
        {
            return _bots.OrderByDescending(o => o.SignalRadius).First();
        }

        public IList<Nanobot> GetBotsInRangeOfStrongestBot()
        {
            var strongestBot = FindStrongestBot();
            return _bots.Where(o => strongestBot.IsInRange(o)).ToList();
        }

        private IList<Nanobot> ParseBots(string input)
        {
            return PuzzleInputReader.Read(input).Select(ParseBot).ToList();
        }

        private Nanobot ParseBot(string s)
        {
            var parts = s.Split(' ');
            var coordParts = parts[0].Replace("pos=<", "").Replace(">", "").Split(',');
            var x = int.Parse(coordParts[0]);
            var y = int.Parse(coordParts[1]);
            var z = int.Parse(coordParts[2]);
            var radius = int.Parse(parts[1].Replace("r=", ""));
            return new Nanobot(new Point3d(x, y, z), radius);
        }
    }
}
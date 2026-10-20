using System.Diagnostics;
using Pzl.Common;
using Pzl.Tools.Grids.Grids3d;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Reactor Reboot")]
public class Aoc202122 : AocPuzzle
{
    [Puzzle("f49f5f28c7496f86abfeaed9d077e669")]
    public long Part1(string input) => Solve(input, 50);

    [Puzzle("1b4e931c995f2d8296dc20828a66283b")]
    public long Part2(string input) => Solve(input);

    public long Solve(string input, int? maxSize = null)
    {
        var lines = input.Split(LineBreaks.Single);
        var instructions = lines.Select(ParseInstruction).ToList();

        var areas = new List<RebootArea>();

        if (maxSize != null)
            instructions = instructions.Where(o => Math.Abs(o.To.X) <= maxSize && Math.Abs(o.To.Z) <= maxSize && Math.Abs(o.To.Z) <= maxSize)
                .ToList();

        foreach (var instruction in instructions)
        {
            var newArea = new RebootArea(instruction.From, instruction.To);
            var areasToAdd = new List<RebootArea>();
            var areasToRemove = new List<RebootArea>();
            if (instruction.Mode == "on")
                areasToAdd.Add(newArea);

            foreach (var area in areas)
            {
                if (!newArea.IsOverlapping(area))
                    continue;
                
                if (!newArea.IsContaining(area))
                {
                    var remainingParts = area.GetRemainingParts(newArea);
                    areasToAdd.AddRange(remainingParts);
                }

                areasToRemove.Add(area);
            }

            foreach (var area in areasToRemove) 
                areas.Remove(area);
            
            areas.AddRange(areasToAdd);
        }

        return areas.Sum(o => o.GetSize());
    }

    private RebootInstruction ParseInstruction(string s)
    {
        var parts = s.Split(' ');
        var mode = parts[0];
        var coords = ParseCoords(parts[1]);

        return new RebootInstruction(mode, coords.from, coords.to);
    }

    private (Coord3d from, Coord3d to) ParseCoords(string s)
    {
        var (x, y, z) = s.Split(',').Select(ParseFromTo).ToArray();
        return (from: new(x.from, y.from, z.from), to: new(x.to, y.to, z.to));
    }

    private (int from, int to) ParseFromTo(string s)
    {
        var (from, to) = Numbers.IntsFromString(s[2..]);
        return (from, to);
    }

    [DebuggerDisplay("{From.X},{From.Y},{From.Z}..{To.X},{To.Y},{To.Z}")]
    public record RebootArea(Coord3d From, Coord3d To)
    {
        public long GetSize()
        {
            long width = To.X - From.X + 1;
            long height = To.Y - From.Y + 1;
            long depth = To.Z - From.Z + 1;

            return width * height * depth;
        }

        public List<RebootArea> GetSortedRemainingParts(RebootArea other) =>
        [
            .. GetRemainingParts(other)
                .OrderBy(o => o.From.X)
                .ThenBy(o => o.From.Y)
                .ThenBy(o => o.From.Z)
                .ThenBy(o => o.To.X)
                .ThenBy(o => o.To.Y)
                .ThenBy(o => o.To.Z)
        ];

        public List<RebootArea> GetRemainingParts(RebootArea other)
        {
            var parts = new List<RebootArea>();
            var cropped = new RebootArea(new(From.X, From.Y, From.Z), new(To.X, To.Y, To.Z));

            // x-axis pos
            if (cropped.From.X <= other.To.X && other.To.X <= cropped.To.X)
            {
                parts.Add(new RebootArea(new(other.To.X + 1, cropped.From.Y, cropped.From.Z),
                    new(cropped.To.X, cropped.To.Y, cropped.To.Z)));
                cropped = new RebootArea(new(cropped.From.X, cropped.From.Y, cropped.From.Z),
                    new(other.To.X, cropped.To.Y, cropped.To.Z));
            }

            // x-axis neg
            if (cropped.From.X <= other.From.X && other.From.X <= cropped.To.X)
            {
                parts.Add(new RebootArea(new(cropped.From.X, cropped.From.Y, cropped.From.Z),
                    new(other.From.X - 1, cropped.To.Y, cropped.To.Z)));
                cropped = new RebootArea(new(other.From.X, cropped.From.Y, cropped.From.Z),
                    new(cropped.To.X, cropped.To.Y, cropped.To.Z));
            }

            // y-axis pos
            if (cropped.From.Y <= other.To.Y && other.To.Y <= cropped.To.Y)
            {
                parts.Add(new RebootArea(new(cropped.From.X, other.To.Y + 1, cropped.From.Z),
                    new(cropped.To.X, cropped.To.Y, cropped.To.Z)));
                cropped = new RebootArea(new(cropped.From.X, cropped.From.Y, cropped.From.Z),
                    new(cropped.To.X, other.To.Y, cropped.To.Z));
            }

            // y-axis neg
            if (cropped.From.Y <= other.From.Y && other.From.Y <= cropped.To.Y)
            {
                parts.Add(new RebootArea(new(cropped.From.X, cropped.From.Y, cropped.From.Z),
                    new(cropped.To.X, other.From.Y - 1, cropped.To.Z)));
                cropped = new RebootArea(new(cropped.From.X, other.From.Y, cropped.From.Z),
                    new(cropped.To.X, cropped.To.Y, cropped.To.Z));
            }

            // z-axis pos
            if (cropped.From.Z <= other.To.Z && other.To.Z <= cropped.To.Z)
            {
                parts.Add(new RebootArea(new(cropped.From.X, cropped.From.Y, other.To.Z + 1),
                    new(cropped.To.X, cropped.To.Y, cropped.To.Z)));
                cropped = new RebootArea(new(cropped.From.X, cropped.From.Y, cropped.From.Z),
                    new(cropped.To.X, cropped.To.Y, other.To.Z));
            }

            // z-axis neg
            if (cropped.From.Z <= other.From.Z && other.From.Z <= cropped.To.Z)
            {
                parts.Add(new RebootArea(new(cropped.From.X, cropped.From.Y, cropped.From.Z),
                    new(cropped.To.X, cropped.To.Y, other.From.Z - 1)));
            }

            return parts;
        }

        public bool IsOverlapping(RebootArea other) =>
            (From.X <= other.To.X && To.X >= other.From.X) &&
            (From.Y <= other.To.Y && To.Y >= other.From.Y) &&
            (From.Z <= other.To.Z && To.Z >= other.From.Z);

        public bool IsContaining(RebootArea other) =>
            From.X < other.From.X && To.X > other.To.X &&
            From.Y < other.From.Y && To.Y > other.To.Y &&
            From.Z < other.From.Z && To.Z > other.To.Z;
    }

    private record RebootInstruction(string Mode, Coord3d From, Coord3d To);
}
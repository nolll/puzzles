using Puzzles.common.CoordinateSystems.CoordinateSystem3D;
using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2021.Aoc202122;

public class SubmarineReactor
{
    public int Reboot(string input)
    {
        var lines = StringReader.ReadLines(input);
        var instructions = lines.Select(ParseInstruction).ToList();

        var matrix = new Matrix3D<char>(50, 50, 50, '.');
        var matrix2 = new Dictionary<(int, int, int), bool>();

        foreach (var instruction in instructions.Where(o => Math.Abs(o.To.X) <= 50 && Math.Abs(o.To.Z) <= 50 && Math.Abs(o.To.Z) <= 50))
        {
            var isOn = instruction.Mode == "on";

            for (var z = instruction.From.Z; z <= instruction.To.Z; z++)
            {
                for (var y = instruction.From.Y; y <= instruction.To.Y; y++)
                {
                    for (var x = instruction.From.X; x <= instruction.To.X; x++)
                    {
                        matrix2[(x, y, z)] = isOn;
                    }
                }
            }
        }

        return matrix2.Values.Count(o => o);
    }

    public long Reboot2(string input, int? maxSize = null)
    {
        var lines = StringReader.ReadLines(input);
        var instructions = lines.Select(ParseInstruction).ToList();

        var areas = new List<RebootArea>();

        if(maxSize != null)
            instructions = instructions.Where(o => Math.Abs(o.To.X) <= maxSize && Math.Abs(o.To.Z) <= maxSize && Math.Abs(o.To.Z) <= maxSize).ToList();

        foreach (var instruction in instructions)
        {
            var newArea = new RebootArea(instruction.From, instruction.To);
            var areasToAdd = new List<RebootArea>();
            var areasToRemove = new List<RebootArea>();
            if (instruction.Mode == "on")
                areasToAdd.Add(newArea);

            foreach (var area in areas)
            {
                if (newArea.IsOverlapping(area))
                {
                    if (!newArea.IsContaining(area))
                    {
                        var remainingParts = area.GetRemainingParts(newArea);
                        areasToAdd.AddRange(remainingParts);
                    }

                    areasToRemove.Add(area);

                }
            }
            
            foreach (var area in areasToRemove)
            {
                areas.Remove(area);
            }

            foreach (var area in areasToAdd)
            {
                areas.Add(area);
            }
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

    private (Matrix3DAddress from, Matrix3DAddress to) ParseCoords(string s)
    {
        var parts = s.Split(',').Select(ParseFromTo).ToList();
        var from = new Matrix3DAddress(parts[0].from, parts[1].from, parts[2].from);
        var to = new Matrix3DAddress(parts[0].to, parts[1].to, parts[2].to);
        return (from, to);
    }

    private (int from, int to) ParseFromTo(string s)
    {
        var parts = s[2..].Split("..").Select(int.Parse).ToList();
        return (parts.First(), parts.Last());
    }
}
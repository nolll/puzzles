using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi02;

[Name("Absurd Arithmetic")]
public class Codyssi02 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var (parameters, rooms) = Parse(input);
        var cost = ApplyFunction(rooms[rooms.Length / 2], parameters);
        
        return new PuzzleResult(cost, "08f294141be67fb8ce4f13e39d3f12d0");
    }

    public PuzzleResult Part2(string input)
    {
        var (parameters, rooms) = Parse(input);
        var cost = ApplyFunction(rooms.Where(o => o % 2 == 0).Sum(), parameters);
        
        return new PuzzleResult(cost, "f53524668fe091cf2cd65be1bf22d73f");
    }

    public PuzzleResult Part3(string input)
    {
        const long max = 15_000_000_000_000;
        
        var (parameters, rooms) = Parse(input);
        (long room, long cost) best = (0, 0);
        foreach (var item in rooms)
        {
            var cost = ApplyFunction(item, parameters);

            if (cost > max || cost <= best.cost)
                continue;

            best = (item, cost);
        }
        
        return new PuzzleResult(best.room, "4366f7c950d582ccdb298e25d136b3b9");
    }

    private static long ApplyFunction(long input, int[] parameters) => 
        (long)Math.Pow(input, parameters[2]) * parameters[1] + parameters[0];

    private static (int[] parameters, long[] rooms) Parse(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var parameters = Numbers.IntsFromString(parts.First());
        var rooms = parts.Last().Split(LineBreaks.Single).Select(long.Parse).Order().ToArray();
        return (parameters, rooms);
    }
}
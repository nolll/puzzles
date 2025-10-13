using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Lists;
using Pzl.Tools.Maths;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202318;

// Googled and found the shoelace formula after hours of failed attempts
[Name("Lavaduct Lagoon")]
public class Aoc202318 : AocPuzzle
{
    public PuzzleResult RunPart1(string input) => new(SolvePart1(input), "61347c48a0a4bc715d0c1c2ea446a36e");
    public PuzzleResult RunPart2(string input) => new(SolvePart2(input), "5ad2f7a72c31e629c55fb65dab16d204");
    public static long SolvePart1(string s) => Solve(ParseInstructionPart1, s);
    public static long SolvePart2(string s) => Solve(ParseInstructionPart2, s);

    private static long Solve(Func<string, Instruction> parse, string s)
    {
        var current = new Point(0, 0);
        List<Point> corners = [current];
        var instructions = ParseInstructions(parse, s);
        
        foreach (var i in instructions)
        {
            var next = new Point(current.X + i.Direction.X * i.Distance, current.Y + i.Direction.Y * i.Distance);
            corners.Add(next);
            current = next;
        }

        return Area(corners);
    }

    private static long Area(List<Point> corners) => GetPicksArea(GetShoelaceArea(corners), GetCircumference(corners));

    private static long GetCircumference(List<Point> corners) => 
        Enumerable.Range(0, corners.Count - 1).Sum(i => ManhattanDistance(corners[i], corners[i + 1]));

    private static long GetPicksArea(long shoelaceArea, long circumference) => shoelaceArea + circumference / 2 + 1;

    private static long GetShoelaceArea(List<Point> coords)
    {
        var sum = Enumerable.Range(0, coords.Count).Sum(i => coords[i].X * (coords[Clamp(i + 1)].Y - coords[Clamp(i - 1)].Y));
        return Math.Abs(sum) / 2;

        int Clamp(int n) => MathTools.Clamp(n, 0, coords.Count - 1);
    }

    public static int ParseHex(string hex) => Convert.ToInt32(hex, 16);
    
    private static IEnumerable<Instruction> ParseInstructions(Func<string, Instruction> parse, string s) => 
        StringReader.ReadLines(s).Select(parse);

    private static Instruction ParseInstructionPart1(string s)
    {
        var ds = s.Split(' ').ToArray()[1];
        return new Instruction(DirectionFromString(s), int.Parse(ds));
    }
    
    private static Instruction ParseInstructionPart2(string s)
    {
        var hex = s.Split(' ').Last().TrimStart('(').TrimEnd(')').TrimStart('#');

        return new Instruction(DirectionFromColor(hex), ParseHex(hex[..5]));
    }
    
    private static GridDirection DirectionFromString(string s) => s[0] switch
    {
        'U' => GridDirection.Up,
        'R' => GridDirection.Right,
        'D' => GridDirection.Down,
        _ => GridDirection.Left
    };

    private static GridDirection DirectionFromColor(string color) => color[^1] switch
    {
        '3' => GridDirection.Up,
        '0' => GridDirection.Right,
        '1' => GridDirection.Down,
        _ => GridDirection.Left
    };
    
    private static long ManhattanDistance(Point a, Point b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

    private record Point(long X, long Y);
    private record Instruction(GridDirection Direction, int Distance);
}

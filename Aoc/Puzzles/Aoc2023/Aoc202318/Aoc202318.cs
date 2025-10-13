using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Maths;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202318;

// Googled and found the shoelace formula after hours of failed attempts
[Name("Lavaduct Lagoon")]
public class Aoc202318 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var result = SolvePart1(input);

        return new PuzzleResult(result, "61347c48a0a4bc715d0c1c2ea446a36e");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = SolvePart2(input);

        return new PuzzleResult(result, "5ad2f7a72c31e629c55fb65dab16d204");
    }

    public static long SolvePart1(string s) => Solve(ParseInstructionPart1, s);
    public static long SolvePart2(string s) => Solve(ParseInstructionPart2, s);

    private static long Solve(Func<string, Instruction> parse, string s)
    {
        var current = new Point(0, 0);
        var corners = new List<Point> { current };
        var instructions = ParseInstructions(parse, s);
        
        foreach (var i in instructions)
        {
            var x = current.X + i.Direction.X * i.Distance;
            var y = current.Y + i.Direction.Y * i.Distance;
            var next = new Point(x, y);
            corners.Add(next);
            current = next;
        }

        return Area(corners);
    }

    private static long Area(List<Point> corners)
    {
        var shoelaceArea = GetShoelaceArea(corners);
        var circumference = GetCircumference(corners);

        return GetPicksArea(shoelaceArea, circumference);
    }

    private static long GetCircumference(List<Point> corners)
    {
        var sum = 0L;
        for (var i = 0; i < corners.Count - 1; i++)
        {
            sum += ManhattanDistance(corners[i], corners[i + 1]);
        }

        return sum;
    }

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
        var parts = s.Split(' ').ToArray();
        var dir = ParseDirectionPart1(parts[0][0]);
        var len = int.Parse(parts[1]);

        return new Instruction(dir, len);
    }
    
    private static Instruction ParseInstructionPart2(string s)
    {
        var parts = s.Split(' ').ToArray();
        var hex = parts[2].TrimStart('(').TrimEnd(')').TrimStart('#');
        var dir = ParseDirectionPart2(hex.Last());
        var len = ParseHex(hex[..5]);

        return new Instruction(dir, len);
    }
    
    private static MatrixDirection ParseDirectionPart1(char c) => c switch
    {
        'U' => MatrixDirection.Up,
        'R' => MatrixDirection.Right,
        'D' => MatrixDirection.Down,
        _ => MatrixDirection.Left
    };

    private static MatrixDirection ParseDirectionPart2(char c) => c switch
    {
        '3' => MatrixDirection.Up,
        '0' => MatrixDirection.Right,
        '1' => MatrixDirection.Down,
        _ => MatrixDirection.Left
    };
    
    private static long ManhattanDistance(Point a, Point b) => 
        Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

    private record Point(long X, long Y);
    private record Instruction(MatrixDirection Direction, int Distance);
}

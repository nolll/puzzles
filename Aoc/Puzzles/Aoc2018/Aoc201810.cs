using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Ocr;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("The Stars Align")]
public class Aoc201810 : AocPuzzle
{
    [Puzzle("fe599bdad14da318ee1e5741dda34bce")]
    public string Part1(string input) => Solve(input, 9).message;

    [Puzzle("05ede0b8fbe47e6f4fba31b20085c653")]
    public int Part2(string input) => Solve(input, 9).iterations;

    public (string starMessage, string message, int iterations) Solve(string input, int messageHeight)
    {
        var i = 0;
        var positions = ParsePositions(input).ToList();
        while (true)
        {
            i++;
            foreach (var position in positions)
                position.Move();

            var yDiff = positions.Max(o => o.Y) - positions.Min(o => o.Y);

            if (yDiff == messageHeight)
                break;
        }

        var starMessage = PrintMessage(positions);
        return (starMessage, OcrLargeFont.ReadString(starMessage), i);
    }

    private static string PrintMessage(List<StarPosition> positions)
    {
        var yOffset = positions.Min(o => o.Y);
        var xOffset = positions.Min(o => o.X);
        var grid = new Grid<char>(1, 1, '.');
        foreach (var position in positions)
        {
            grid.MoveTo(position.X - xOffset, position.Y - yOffset);
            grid.WriteValue('#');
        }

        return grid.Print();
    }

    private static IEnumerable<StarPosition> ParsePositions(string input)
    {
        var strings = input.Split(LineBreaks.Single);
        foreach (var s in strings)
            yield return ParsePosition(s);
    }

    private static StarPosition ParsePosition(string s)
    {
        var positionEndsAt = s.IndexOf('>') + 1;
        var strPos = s[..positionEndsAt];
        var strVel = s.Replace(strPos, "");

        var tPos = ParseXy(strPos);
        var tVel = ParseXy(strVel);

        return new StarPosition(tPos.x, tPos.y, tVel.x, tVel.y);
    }

    private static (int x, int y) ParseXy(string s)
    {
        var angle1 = s.IndexOf('<');
        var comma = s.IndexOf(',');
        var angle2 = s.IndexOf('>');
        var x = int.Parse(s.Substring(angle1 + 1, comma - angle1 - 1).Trim());
        var y = int.Parse(s.Substring(comma + 1, angle2 - comma - 1).Trim());
        return (x, y);
    }

    private class StarPosition(int x, int y, int vx, int vy)
    {
        public int X { get; private set; } = x;
        public int Y { get; private set; } = y;

        public void Move()
        {
            X += vx;
            Y += vy;
        }
    }
}
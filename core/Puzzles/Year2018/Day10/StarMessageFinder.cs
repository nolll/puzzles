using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using Core.Common.Strings;

namespace Core.Puzzles.Year2018.Day10;

public class StarMessageFinder
{
    public string Message { get; }
    public int IterationCount { get; }

    public StarMessageFinder(string input, int messageHeight)
    {
        var positions = ParsePositions(input).ToList();
        while (true)
        {
            IterationCount++;
            foreach (var position in positions)
            {
                position.Move();
            }

            var yDiff = positions.Max(o => o.Y) - positions.Min(o => o.Y);

            if (yDiff == messageHeight)
            {
                Message = PrintMessage(positions);
                return;
            }
        }
    }

    private string PrintMessage(List<StarPosition> positions)
    {
        var yOffset = positions.Min(o => o.Y);
        var xOffset = positions.Min(o => o.X);
        var matrix = new Matrix<char>(1, 1, '.');
        foreach (var position in positions)
        {
            matrix.MoveTo(position.X - xOffset, position.Y - yOffset);
            matrix.WriteValue('#');
        }
        return matrix.Print();
    }

    private IEnumerable<StarPosition> ParsePositions(string input)
    {
        var strings = PuzzleInputReader.ReadLines(input);
        foreach (var s in strings)
        {
            yield return ParsePosition(s);
        }
    }

    private StarPosition ParsePosition(string s)
    {
        var positionEndsAt = s.IndexOf(">", StringComparison.InvariantCulture) + 1;
        var strPos = s.Substring(0, positionEndsAt);
        var strVel = s.Replace(strPos, "");

        var tPos = ParseXy(strPos);
        var tVel = ParseXy(strVel);

        return new StarPosition(tPos.x, tPos.y, tVel.x, tVel.y);
    }

    private (int x, int y) ParseXy(string s)
    {
        var angle1 = s.IndexOf("<", StringComparison.InvariantCulture);
        var comma = s.IndexOf(",", StringComparison.InvariantCulture);
        var angle2 = s.IndexOf(">", StringComparison.InvariantCulture);
        var x = int.Parse(s.Substring(angle1 + 1, comma - angle1 - 1).Trim());
        var y = int.Parse(s.Substring(comma + 1, angle2 - comma - 1).Trim());
        return (x, y);
    }
}
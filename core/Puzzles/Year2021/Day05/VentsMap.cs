using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems;
using Core.Common.Strings;

namespace Core.Puzzles.Year2021.Day05;

public class VentsMap
{
    public int Run(string input, bool perpendicularOnly)
    {
        var rows = PuzzleInputReader.ReadLines(input);
        var lines = ParseLines(rows);
        if (perpendicularOnly)
            lines = lines.Where(o => o.IsPerpendicular).ToList();
        var width = lines.Max(o => Math.Max(o.Start.X, o.End.X));
        var height = lines.Max(o => Math.Max(o.Start.Y, o.End.Y));
        var matrix = new DynamicMatrix<int>(width, height);

        matrix = MapLines(matrix, lines);
        var c = matrix.Values.Count(o => o >= 2);

        return c;
    }

    private DynamicMatrix<int> MapLines(DynamicMatrix<int> matrix, List<Line2d> lines)
    {
        foreach (var line in lines)
        {
            foreach (var pos in line.Positions)
            {
                matrix.MoveTo(pos.X, pos.Y);
                var v = matrix.ReadValue();
                v += 1;
                matrix.WriteValue(v);
            }
        }

        return matrix;
    }

    private List<Line2d> ParseLines(IList<string> rows)
    {
        return rows.Select(ParseLine).ToList();
    }

    private Line2d ParseLine(string s)
    {
        var positions = s.Split(" -> ").Select(ParsePosition).ToList();
        return new Line2d(positions[0], positions[1]);
    }

    private Position2d ParsePosition(string s)
    {
        var parts = s.Split(',').Select(int.Parse).ToArray();
        return new Position2d(parts[0], parts[1]);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using Core.Common.Strings;
using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day14;

public class FallingSand
{
    public int Part1(string input)
    {
        var matrix = new DynamicMatrix<char>(1, 1, '.');
        var lines = PuzzleInputReader.ReadLines(input, false);

        var coordLists = lines.Select(o => o.Split(" -> "));
        foreach (var coordList in coordLists)
        {
            var coords = new List<MatrixAddress>();
            foreach (var coord in coordList)
            {
                var parts = coord.Split(',');
                var x = int.Parse(parts[0]);
                var y = int.Parse(parts[1]);
                coords.Add(new MatrixAddress(x, y));
            }

            for (var i = 1; i < coords.Count; i++)
            {
                var a = coords[i - 1];
                var b = coords[i];

                var minX = Math.Min(a.X, b.X);
                var minY = Math.Min(a.Y, b.Y);
                var maxX = Math.Max(a.X, b.X);
                var maxY = Math.Max(a.Y, b.Y);

                var dx = a.X - b.X;
                var dy = a.Y - b.Y;

                if (a.X == b.X)
                {
                    var x = a.X;
                    for (var y = minY; y <= maxY; y++)
                    {
                        matrix.MoveTo(x, y);
                        matrix.WriteValueAt(x, y, '#');
                    }
                }
                else
                {
                    var y = a.Y;
                    for (var x = minX; x <= maxX; x++)
                    {
                        matrix.MoveTo(x, y);
                        matrix.WriteValueAt(x, y, '#');
                    }
                }
            }
        }

        matrix.ExtendRight();
        var sandSource = new MatrixAddress(500, 0);
        matrix.MoveTo(sandSource);
        while (matrix.ReadValueAt(sandSource) == '.')
        {
            var currentSand = new MatrixAddress(500, 0);
            var section = matrix.Slice(new MatrixAddress(480, 0));

            while (TryMove(matrix, currentSand, out var newSand))
            {
                currentSand = newSand;

                if (currentSand.Y == matrix.Height - 1)
                {
                    break;
                }
            }

            if (currentSand.Y == matrix.Height - 1)
            {
                break;
            }

            matrix.WriteValueAt(currentSand, 'o');
        }

        return matrix.Values.Count(o => o == 'o');
    }

    public int Part2(string input)
    {
        var matrix = new DynamicMatrix<char>(1, 1, '.');
        var lines = PuzzleInputReader.ReadLines(input, false);

        var coordLists = lines.Select(o => o.Split(" -> "));
        foreach (var coordList in coordLists)
        {
            var coords = new List<MatrixAddress>();
            foreach (var coord in coordList)
            {
                var parts = coord.Split(',');
                var x = int.Parse(parts[0]);
                var y = int.Parse(parts[1]);
                coords.Add(new MatrixAddress(x, y));
            }

            for (var i = 1; i < coords.Count; i++)
            {
                var a = coords[i - 1];
                var b = coords[i];

                var minX = Math.Min(a.X, b.X);
                var minY = Math.Min(a.Y, b.Y);
                var maxX = Math.Max(a.X, b.X);
                var maxY = Math.Max(a.Y, b.Y);

                var dx = a.X - b.X;
                var dy = a.Y - b.Y;

                if (a.X == b.X)
                {
                    var x = a.X;
                    for (var y = minY; y <= maxY; y++)
                    {
                        matrix.MoveTo(x, y);
                        matrix.WriteValueAt(x, y, '#');
                    }
                }
                else
                {
                    var y = a.Y;
                    for (var x = minX; x <= maxX; x++)
                    {
                        matrix.MoveTo(x, y);
                        matrix.WriteValueAt(x, y, '#');
                    }
                }
            }
        }

        matrix.ExtendRight(1000);
        matrix.ExtendDown();
        matrix.ExtendDown();
        var sy = matrix.Height - 1;
        for (var x = 0; x < matrix.Width; x++)
        {
            matrix.WriteValueAt(x, sy, '#');
        }

        var sandSource = new MatrixAddress(500, 0);
        matrix.MoveTo(sandSource);
        while (matrix.ReadValueAt(sandSource) == '.')
        {
            var currentSand = new MatrixAddress(500, 0);
            var section = matrix.Slice(new MatrixAddress(480, 0));

            while (TryMove(matrix, currentSand, out var newSand))
            {
                currentSand = newSand;
            }

            matrix.WriteValueAt(currentSand, 'o');
        }

        return matrix.Values.Count(o => o == 'o');
    }

    private bool TryMove(IMatrix<char> matrix, MatrixAddress currentSand, out MatrixAddress newSand)
    {
        var down = new MatrixAddress(currentSand.X, currentSand.Y + 1);
        matrix.MoveTo(down);

        if (matrix.ReadValueAt(down) == '.')
        {
            newSand = down;
            return true;
        }

        var downLeft = new MatrixAddress(down.X - 1, down.Y);
        matrix.MoveTo(downLeft);
        if (matrix.ReadValueAt(downLeft) == '.')
        {
            newSand = downLeft;
            return true;
        }

        var downRight = new MatrixAddress(down.X + 1, down.Y);
        matrix.MoveTo(downRight);
        if (matrix.ReadValueAt(downRight) == '.')
        {
            newSand = downRight;
            return true;
        }

        newSand = currentSand;
        return false;
    }
}

public class Year2022Day14Tests
{
    [Test]
    public void Part1()
    {
        var fallingSand = new FallingSand();
        var result = fallingSand.Part1(Input);

        Assert.That(result, Is.EqualTo(24));
    }

    [Test]
    public void Part2()
    {
        var fallingSand = new FallingSand();
        var result = fallingSand.Part2(Input);

        Assert.That(result, Is.EqualTo(93));
    }

    private const string Input = @"
498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9";
}
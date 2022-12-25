using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using Core.Platform;
using Core.Puzzles.Year2021.Day09;

namespace Core.Puzzles.Year2022.Day24;

public class Year2022Day24 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var result = Part1(FileInput);
        return new PuzzleResult(result);
    }

    public int Part1(string input)
    {
        var matrix = MatrixBuilder.BuildStaticCharMatrix(input);
        var blizzards = new List<Blizzard>();
        MatrixAddress enter = null;
        MatrixAddress exit = null;
        foreach (var coord in matrix.Coords)
        {
            matrix.MoveTo(coord);
            var value = matrix.ReadValue();
            if (value == 'E')
            {
                enter = coord;
                matrix.WriteValue('#');
            }
            else if (coord.Y == matrix.YMax && value == '.')
            {
                exit = coord;
            }
            else if (value == '^')
            {
                blizzards.Add(new Blizzard(MatrixDirection.Up, coord));
                matrix.WriteValue('.');
            }
            else if (value == '>')
            {
                blizzards.Add(new Blizzard(MatrixDirection.Right, coord));
                matrix.WriteValue('.');
            }
            else if (value == 'v')
            {
                blizzards.Add(new Blizzard(MatrixDirection.Down, coord));
                matrix.WriteValue('.');
            }
            else if (value == '<')
            {
                blizzards.Add(new Blizzard(MatrixDirection.Left, coord));
                matrix.WriteValue('.');
            }
        }

        if (enter == null || exit == null)
            throw new Exception("Enter or Exit not found");

        var queue = new List<BlizzardCoordCount> { new(enter.X, enter.Y, 0, blizzards, "") };
        var index = 0;
        while (index < queue.Count && !queue.Any(o => o.X == exit.X && o.Y == exit.Y))
        {
            var next = queue[index];
            matrix.MoveTo(next.X, next.Y);

            var movedBlizzards = new List<Blizzard>();
            foreach (var blizzard in next.Blizzards)
            {
                var x = blizzard.Address.X;
                var y = blizzard.Address.Y;
                if (blizzard.Direction.Equals(MatrixDirection.Up))
                {
                    var newCoord = new MatrixAddress(x, y - 1);
                    if (matrix.ReadValueAt(newCoord) == '#')
                    {
                        newCoord = new MatrixAddress(x, matrix.Height - 1);
                    }
                    movedBlizzards.Add(new Blizzard(blizzard.Direction, newCoord));
                }
                else if (blizzard.Direction.Equals(MatrixDirection.Right))
                {
                    var newCoord = new MatrixAddress(x + 1, y);
                    if (matrix.ReadValueAt(newCoord) == '#')
                    {
                        newCoord = new MatrixAddress(1, y);
                    }
                    movedBlizzards.Add(new Blizzard(blizzard.Direction, newCoord));
                }
                else if (blizzard.Direction.Equals(MatrixDirection.Down))
                {
                    var newCoord = new MatrixAddress(x, y + 1);
                    if (matrix.ReadValueAt(newCoord) == '#')
                    {
                        newCoord = new MatrixAddress(x, 1);
                    }
                    movedBlizzards.Add(new Blizzard(blizzard.Direction, newCoord));
                }
                else
                {
                    var newCoord = new MatrixAddress(x - 1, y);
                    if (matrix.ReadValueAt(newCoord) == '#')
                    {
                        newCoord = new MatrixAddress(matrix.Width - 1, y);
                    }
                    movedBlizzards.Add(new Blizzard(blizzard.Direction, newCoord));
                }
            }
            var newMatrix = matrix.Copy();
            foreach (var blizzard in movedBlizzards)
            {
                newMatrix.WriteValueAt(blizzard.Address, '#');
            }

            var print = newMatrix.Print();

            var adjacentCoords = matrix.PerpendicularAdjacentCoords
                .Where(o => matrix.ReadValueAt(o) == '.' && !queue.Any(q => q.X == o.X && q.Y == o.Y && q.Print == print))
                .ToList();
            var newCoordCounts = adjacentCoords.Select(o => new BlizzardCoordCount(o.X, o.Y, next.Count + 1, movedBlizzards, print));
            queue.AddRange(newCoordCounts);
            if (!adjacentCoords.Any() && matrix.ReadValueAt(next.X, next.Y) == '.')
            {
                queue.Add(new BlizzardCoordCount(next.X, next.Y, next.Count + 1, movedBlizzards, print));
            }
            index++;
        }
        
        return queue.FirstOrDefault(o => o.X == exit.X && o.Y == exit.Y)?.Count ?? 0;
    }
    
    public class Blizzard
    {
        public MatrixDirection Direction { get; }
        public MatrixAddress Address { get; }

        public Blizzard(MatrixDirection direction, MatrixAddress address)
        {
            Direction = direction;
            Address = address;
        }

        public char Display
        {
            get
            {
                if (Direction.Equals(MatrixDirection.Up))
                    return '^';
                if (Direction.Equals(MatrixDirection.Right))
                    return '>';
                if (Direction.Equals(MatrixDirection.Down))
                    return 'v';
                return '<';
            }
        }
    }

    [DebuggerDisplay("{X},{Y},{Count}")]
    public class BlizzardCoordCount
    {
        public int X { get; }
        public int Y { get; }
        public int Count { get; }
        public List<Blizzard> Blizzards { get; }
        public string Print { get; }

        public BlizzardCoordCount(int x, int y, int count, List<Blizzard> blizzards, string print)
        {
            X = x;
            Y = y;
            Count = count;
            Blizzards = blizzards;
            Print = print;
        }

        public BlizzardCoordCount(MatrixAddress coord, int count)
        {
            X = coord.X;
            Y = coord.Y;
            Count = count;
        }
    }

    public override PuzzleResult RunPart2()
    {
        return new EmptyPuzzleResult();
    }
}
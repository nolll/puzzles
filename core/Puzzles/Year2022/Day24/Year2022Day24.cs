using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using Core.Platform;

namespace Core.Puzzles.Year2022.Day24;

public class Year2022Day24 : Puzzle
{
    private const char Up = '^';
    private const char Right = '>';
    private const char Down = 'v';
    private const char Left = '<';

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
            if (value == 'E' || coord.Y == matrix.YMin && value == '.')
            {
                enter = coord;
                matrix.WriteValue('#');
            }
            else if (coord.Y == matrix.YMax && value == '.')
            {
                exit = coord;
            }
            else if (value != '#' && value != '.')
            {
                blizzards.Add(new Blizzard(value, coord));
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
                if (blizzard.Direction == Up)
                {
                    var newCoord = new MatrixAddress(x, y - 1);
                    if (newCoord.Y == matrix.YMin)
                    {
                        newCoord = new MatrixAddress(x, matrix.YMax - 1);
                    }
                    movedBlizzards.Add(new Blizzard(blizzard.Direction, newCoord));
                }
                else if (blizzard.Direction == Right)
                {
                    var newCoord = new MatrixAddress(x + 1, y);
                    if (newCoord.X == matrix.XMax)
                    {
                        newCoord = new MatrixAddress(1, y);
                    }
                    movedBlizzards.Add(new Blizzard(blizzard.Direction, newCoord));
                }
                else if (blizzard.Direction == Down)
                {
                    var newCoord = new MatrixAddress(x, y + 1);
                    if (newCoord.Y == matrix.YMax)
                    {
                        newCoord = new MatrixAddress(x, 1);
                    }
                    movedBlizzards.Add(new Blizzard(blizzard.Direction, newCoord));
                }
                else
                {
                    var newCoord = new MatrixAddress(x - 1, y);
                    if (newCoord.X == matrix.XMin)
                    {
                        newCoord = new MatrixAddress(matrix.XMax - 1, y);
                    }
                    movedBlizzards.Add(new Blizzard(blizzard.Direction, newCoord));
                }
            }
            var newMatrix = matrix.Copy();
            foreach (var blizzard in movedBlizzards)
            {
                //newMatrix.WriteValueAt(blizzard.Address, blizzard.Direction);
                var v = newMatrix.ReadValueAt(blizzard.Address);
                if (v == '.')
                    newMatrix.WriteValueAt(blizzard.Address, blizzard.Direction);
                else if (int.TryParse(v.ToString(), out var i))
                    newMatrix.WriteValueAt(blizzard.Address, (i + 1).ToString().First());
                else
                    newMatrix.WriteValueAt(blizzard.Address, '2');
            }
            newMatrix.WriteValueAt(next.X, next.Y, 'E');
            //Console.WriteLine(next.Count);
            //Console.WriteLine(newMatrix.Print());
            //Console.WriteLine();

            var print = newMatrix.Print();

            var adjacentCoords = newMatrix.PerpendicularAdjacentCoords
                .Where(o => newMatrix.ReadValueAt(o) == '.' && !queue.Any(q => q.X == o.X && q.Y == o.Y && q.Print == print))
                .ToList();
            var newCoordCounts = adjacentCoords.Select(o => new BlizzardCoordCount(o.X, o.Y, next.Count + 1, movedBlizzards, print));
            queue.AddRange(newCoordCounts);
            if (!adjacentCoords.Any())
            {
                queue.Add(new BlizzardCoordCount(next.X, next.Y, next.Count + 1, movedBlizzards, print));
            }
            index++;
        }
        
        return queue.FirstOrDefault(o => o.X == exit.X && o.Y == exit.Y)?.Count ?? 0;
    }
    
    public class Blizzard
    {
        public char Direction { get; }
        public MatrixAddress Address { get; }

        public Blizzard(char direction, MatrixAddress address)
        {
            Direction = direction;
            Address = address;
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
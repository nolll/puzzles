using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        // guess 210, too low

        return new PuzzleResult(result);
    }

    public int Part1(string input)
    {
        var matrix = MatrixBuilder.BuildStaticCharMatrix(input);
        var blizzards = new List<Blizzard>();
        MatrixAddress enter = null;
        MatrixAddress exit = null;
        var walls = new List<MatrixAddress>();
        var neighborCache = new Dictionary<MatrixAddress, IList<MatrixAddress>>();
        foreach (var coord in matrix.Coords)
        {
            matrix.MoveTo(coord);
            var value = matrix.ReadValue();
            if (value == 'E' || coord.Y == matrix.YMin && value == '.')
            {
                enter = coord;
                matrix.WriteValue('#');
                walls.Add(coord);
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
            else if (value == '#')
            {
                walls.Add(coord);
            }

            neighborCache.Add(matrix.Address, matrix.PerpendicularAdjacentCoords.Where(o => !o.Equals(enter)).ToList());
        }

        if (enter == null || exit == null)
            throw new Exception("Enter or Exit not found");

        var prints = new HashSet<string>();
        var uniqueBlizzards = new List<ImmutableHashSet<MatrixAddress>>();
        while (true)
        {
            var print = PrintMatrix(matrix, blizzards);
            if (prints.Contains(print))
            {
                break;
            }

            prints.Add(print);
            var addresses = blizzards.Distinct().Select(o => o.Address).Union(walls);
            var blizzardSet = addresses.ToImmutableHashSet();
            uniqueBlizzards.Add(blizzardSet);
            blizzards = MoveBlizzards(matrix, blizzards);
        }

        var uniqueCount = uniqueBlizzards.Count;

        // Tried to use the full blizzard cycle, without looking for existing prints. Same result, only slower
        //var uniqueCount = (matrix.Width - 2) * (matrix.Height - 2);
        //var uniqueCounter = 0;
        //while (uniqueCounter < uniqueCount)
        //{
        //    var print = PrintMatrix(matrix, blizzards);
        //    prints.Add(print);
        //    var addresses = blizzards.Distinct().Select(o => o.Address).Union(walls);
        //    var blizzardSet = addresses.ToImmutableHashSet();
        //    uniqueBlizzards.Add(blizzardSet);
        //    blizzards = MoveBlizzards(matrix, blizzards);
        //    uniqueCounter++;
        //}

        var seen = new HashSet<(MatrixAddress, int)>();
        var queue = new List<BlizzardCoordCount> { new(enter, 0) };
        var index = 0;

        while (index < queue.Count)
        {
            var next = queue[index];
            var nextCount = next.Count + 1;
            var nextState = nextCount % uniqueCount;
            var blizzardSet = uniqueBlizzards[nextState];
            
            var adjacentCoords = neighborCache[next.Coord]
                .Where(o => !blizzardSet.Contains(o) && !seen.Contains((o, nextState)))
                .ToList();
            var newCoordCounts = adjacentCoords.Select(o => new BlizzardCoordCount(o, nextCount)).ToList();
            if (!adjacentCoords.Any() && !seen.Contains((next.Coord, nextState)))
            {
                newCoordCounts.Add(new BlizzardCoordCount(next.Coord, nextCount));
            }

            foreach (var coordCount in newCoordCounts)
            {
                queue.Add(coordCount);
                seen.Add((coordCount.Coord, nextState));
            }

            if (newCoordCounts.Any(o => o.Coord.X == exit.X && o.Coord.Y == exit.Y))
            {
                break;
            }

            index++;
        }
        
        return queue.FirstOrDefault(o => o.Coord.X == exit.X && o.Coord.Y == exit.Y)?.Count ?? 0;
    }

    private List<Blizzard> MoveBlizzards(IMatrix<char> matrix, List<Blizzard> blizzards)
    {
        var movedBlizzards = new List<Blizzard>();
        foreach (var blizzard in blizzards)
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

        return movedBlizzards;
    }

    private string PrintMatrix(IMatrix<char> matrix, List<Blizzard> blizzards)
    {
        var newMatrix = matrix.Copy();
        foreach (var blizzard in blizzards)
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

        return newMatrix.Print();
    }

    private string PrintMatrix(IMatrix<char> matrix, List<MatrixAddress> coords)
    {
        var newMatrix = matrix.Copy();
        foreach (var coord in coords)
        {
            newMatrix.WriteValueAt(coord, 'o');
        }

        return newMatrix.Print();
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
        public MatrixAddress Coord { get; }
        public int Count { get; }

        public int X => Coord.X;
        public int Y => Coord.Y;

        public BlizzardCoordCount(MatrixAddress coord, int count)
        {
            Coord = coord;
            Count = count;
        }
    }

    public override PuzzleResult RunPart2()
    {
        return new EmptyPuzzleResult();
    }
}
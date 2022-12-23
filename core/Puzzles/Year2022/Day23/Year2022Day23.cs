using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using Core.Platform;

namespace Core.Puzzles.Year2022.Day23;

public class Year2022Day23 : Puzzle
{
    private readonly (int x, int y) _north = (0, -1);
    private readonly (int x, int y) _northEast = (1, -1);
    private readonly (int x, int y) _east = (1, 0);
    private readonly (int x, int y) _southEast = (1, 1);
    private readonly (int x, int y) _south = (0, 1);
    private readonly (int x, int y) _southWest = (-1, 1);
    private readonly (int x, int y) _west = (-1, 0);
    private readonly (int x, int y) _northWest = (-1, -1);

    public override PuzzleResult RunPart1()
    {
        var (emptyCount, _) = Run(FileInput, 10);

        return new PuzzleResult(emptyCount, 4181);
    }

    public override PuzzleResult RunPart2()
    {
        var (_, endRound) = Run(FileInput);

        return new PuzzleResult(endRound, 973);
    }

    public (int emptyCount, int endRound) Run(string input, int rounds = int.MaxValue)
    {
        var matrix = (IDynamicMatrix<char>)MatrixBuilder.BuildCharMatrix(input, '.');
        matrix.ExtendAllDirections(100);
        var elfs = matrix.Coords.Where(o => matrix.ReadValueAt(o) == '#').ToArray();
        var searchDeltas = new List<List<(int x, int y)>>
        {
            new() { _north, _northWest, _northEast },
            new() { _south, _southWest, _southEast },
            new() { _west, _northWest, _southWest },
            new() { _east, _northEast, _southEast }
        };

        var searchResults = new List<(int x, int y)>
        {
            _north,
            _south,
            _west,
            _east
        };

        var startDeltaIndex = 0;
        var round = 0;

        while(round < rounds)
        {
            var targets = new MatrixAddress[elfs.Length];
            for (var j = 0; j < elfs.Length; j++)
            {
                var needsToMove = matrix.AllAdjacentValuesTo(elfs[j]).Any(o => o == '#');
                if (!needsToMove)
                    continue;

                for (var m = startDeltaIndex; m < searchDeltas.Count + startDeltaIndex; m++)
                {
                    var deltaIndex = m % searchDeltas.Count;
                    var foundElf = false;
                    for (var k = 0; k < searchDeltas[deltaIndex].Count; k++)
                    {
                        var delta = searchDeltas[deltaIndex][k];
                        var searchAddress = new MatrixAddress(elfs[j].X + delta.x, elfs[j].Y + delta.y);
                        if (!matrix.IsOutOfRange(searchAddress) && matrix.ReadValueAt(searchAddress) == '#')
                            foundElf = true;
                    }

                    if (!foundElf)
                    {
                        var selectedDelta = searchResults[deltaIndex];
                        var target = new MatrixAddress(elfs[j].X + selectedDelta.x, elfs[j].Y + selectedDelta.y);
                        targets[j] = target;
                        break;
                    }
                }
            }

            if (targets.All(o => o == null))
            {
                round++;
                break;
            }

            for (var j = 0; j < elfs.Length; j++)
            {
                var to = targets[j];
                var same = targets.Where(o => o != null).Where(o => o.Equals(to));

                if (same.Count() == 1)
                {
                    var from = elfs[j];
                    matrix.MoveTo(from);
                    matrix.WriteValueAt(from, '.');
                    elfs[j] = to;
                    matrix.MoveTo(to);
                    matrix.WriteValue('#');
                }
            }

            startDeltaIndex = (startDeltaIndex + 1) % searchDeltas.Count;
            round++;
        }

        var minX = elfs.Select(o => o.X).Min();
        var minY = elfs.Select(o => o.Y).Min();
        var maxX = elfs.Select(o => o.X).Max();
        var maxY = elfs.Select(o => o.Y).Max();

        var width = maxX - minX + 1;
        var height = maxY - minY + 1;
        var area = width * height;
        var emptyCount = area - elfs.Length;

        return (emptyCount, round);
    }
}
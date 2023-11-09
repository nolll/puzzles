using System.Collections.Generic;
using System.Linq;
using Common.CoordinateSystems.CoordinateSystem2D;
using Common.Puzzles;
using Common.Strings;

namespace Aoc.Puzzles.Aoc2022.Aoc202223;

public class Aoc202223 : AocPuzzle
{
    public override string Name => "Unstable Diffusion";

    protected override PuzzleResult RunPart1()
    {
        var (emptyCount, _) = Run(InputFile, 10);

        return new PuzzleResult(emptyCount, "b2078a7c2a582e68796f55a71f1fe1cd");
    }

    protected override PuzzleResult RunPart2()
    {
        var (_, endRound) = Run(InputFile);

        return new PuzzleResult(endRound, "b4b9f7dae4709930cd73d70f45eac0ae");
    }

    private readonly (int x, int y) _north = (0, -1);
    private readonly (int x, int y) _northEast = (1, -1);
    private readonly (int x, int y) _east = (1, 0);
    private readonly (int x, int y) _southEast = (1, 1);
    private readonly (int x, int y) _south = (0, 1);
    private readonly (int x, int y) _southWest = (-1, 1);
    private readonly (int x, int y) _west = (-1, 0);
    private readonly (int x, int y) _northWest = (-1, -1);
    private readonly List<List<(int x, int y)>> _searchDeltas;
    private readonly List<(int x, int y)> _searchResults;
    private readonly List<(int x, int y)> _deltas;

    public Aoc202223()
    {
        _searchDeltas = new List<List<(int x, int y)>>
        {
            new() { _north, _northWest, _northEast },
            new() { _south, _southWest, _southEast },
            new() { _west, _northWest, _southWest },
            new() { _east, _northEast, _southEast }
        };

        _searchResults = new List<(int x, int y)>
        {
            _north,
            _south,
            _west,
            _east
        };

        _deltas = new List<(int x, int y)>
        {
            _north,
            _northEast,
            _east,
            _southEast,
            _south,
            _southWest,
            _west,
            _northWest,
        };
    }

    public (int emptyCount, int endRound) Run(string input, int rounds = int.MaxValue)
    {
        var elves = ParseElves(input);

        var startDeltaIndex = 0;
        var round = 0;

        while(round < rounds)
        {
            var targets = new Dictionary<MatrixAddress, MatrixAddress>();
            var targetCount = new Dictionary<MatrixAddress, int>();

            foreach (var elf in elves)
            {
                var needsToMove = HasNeighbors(elves, elf);
                if (!needsToMove)
                    continue;

                for (var m = startDeltaIndex; m < _searchDeltas.Count + startDeltaIndex; m++)
                {
                    var deltaIndex = m % _searchDeltas.Count;
                    var foundElf = false;
                    for (var k = 0; k < _searchDeltas[deltaIndex].Count; k++)
                    {
                        var (dx, dy) = _searchDeltas[deltaIndex][k];
                        var searchAddress = new MatrixAddress(elf.X + dx, elf.Y + dy);
                        if (elves.Contains(searchAddress))
                            foundElf = true;
                    }

                    if (!foundElf)
                    {
                        var (dx, dy) = _searchResults[deltaIndex];
                        var target = new MatrixAddress(elf.X + dx, elf.Y + dy);
                        targets[elf] = target;
                        if (!targetCount.TryAdd(target, 1))
                            targetCount[target]++;
                        break;
                    }
                }
            }

            if (!targets.Any())
            {
                round++;
                break;
            }

            foreach (var elf in elves.ToList())
            {
                if (!targets.TryGetValue(elf, out var to))
                    continue;

                if (targetCount[to] == 1)
                {
                    elves.Remove(elf);
                    elves.Add(to);
                }
            }

            startDeltaIndex = (startDeltaIndex + 1) % _searchDeltas.Count;
            round++;
        }

        var minX = elves.Select(o => o.X).Min();
        var minY = elves.Select(o => o.Y).Min();
        var maxX = elves.Select(o => o.X).Max();
        var maxY = elves.Select(o => o.Y).Max();
        var elfCount = elves.Count;

        var width = maxX - minX + 1;
        var height = maxY - minY + 1;
        var area = width * height;
        var emptyCount = area - elfCount;

        return (emptyCount, round);
    }

    private HashSet<MatrixAddress> ParseElves(string input)
    {
        var elves = new HashSet<MatrixAddress>();
        var lines = PuzzleInputReader.ReadLines(input);
        for (var y = 0; y < lines.Count; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                if (line[x] == '#')
                    elves.Add(new MatrixAddress(x, y));
            }
        }

        return elves;
    }

    private bool HasNeighbors(HashSet<MatrixAddress> elfs, MatrixAddress elf)
    {
        foreach (var delta in _deltas)
        {
            var neighbor = new MatrixAddress(elf.X + delta.x, elf.Y + delta.y);
            if (elfs.Contains(neighbor))
                return true;
        }

        return false;
    }

    private string Print(HashSet<MatrixAddress> coords)
    {
        var matrix = new Matrix<char>(1, 1, '.');
        foreach (var coord in coords)
        {
            matrix.MoveTo(coord);
            matrix.WriteValue('#');
        }

        return matrix.Print();
    }
}
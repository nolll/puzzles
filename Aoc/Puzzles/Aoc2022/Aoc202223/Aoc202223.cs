using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202223;

[Name("Unstable Diffusion")]
public class Aoc202223 : AocPuzzle
{
    private static readonly (int x, int y) North = (0, -1);
    private static readonly (int x, int y) NorthEast = (1, -1);
    private static readonly (int x, int y) East = (1, 0);
    private static readonly (int x, int y) SouthEast = (1, 1);
    private static readonly (int x, int y) South = (0, 1);
    private static readonly (int x, int y) SouthWest = (-1, 1);
    private static readonly (int x, int y) West = (-1, 0);
    private static readonly (int x, int y) NorthWest = (-1, -1);

    private readonly List<List<(int x, int y)>> _searchDeltas = new()
    {
        new () { North, NorthWest, NorthEast },
        new () { South, SouthWest, SouthEast },
        new() { West, NorthWest, SouthWest },
        new() { East, NorthEast, SouthEast }
    };

    private readonly List<(int x, int y)> _searchResults = new()
    {
        North,
        South,
        West,
        East
    };

    private readonly List<(int x, int y)> _deltas = new()
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest,
    };

    public PuzzleResult RunPart1(string input)
    {
        var (emptyCount, _) = Run(input, 10);

        return new PuzzleResult(emptyCount, "b2078a7c2a582e68796f55a71f1fe1cd");
    }

    public PuzzleResult RunPart2(string input)
    {
        var (_, endRound) = Run(input);

        return new PuzzleResult(endRound, "b4b9f7dae4709930cd73d70f45eac0ae");
    }
    
    public (int emptyCount, int endRound) Run(string input, int rounds = int.MaxValue)
    {
        var elves = ParseElves(input);

        var startDeltaIndex = 0;
        var round = 0;

        while(round < rounds)
        {
            var targets = new Dictionary<Coord, Coord>();
            var targetCount = new Dictionary<Coord, int>();

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
                        var searchAddress = new Coord(elf.X + dx, elf.Y + dy);
                        if (elves.Contains(searchAddress))
                            foundElf = true;
                    }

                    if (!foundElf)
                    {
                        var (dx, dy) = _searchResults[deltaIndex];
                        var target = new Coord(elf.X + dx, elf.Y + dy);
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

    private HashSet<Coord> ParseElves(string input)
    {
        var elves = new HashSet<Coord>();
        var lines = StringReader.ReadLines(input);
        for (var y = 0; y < lines.Count; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                if (line[x] == '#')
                    elves.Add(new Coord(x, y));
            }
        }

        return elves;
    }

    private bool HasNeighbors(HashSet<Coord> elfs, Coord elf)
    {
        foreach (var delta in _deltas)
        {
            var neighbor = new Coord(elf.X + delta.x, elf.Y + delta.y);
            if (elfs.Contains(neighbor))
                return true;
        }

        return false;
    }

    private string Print(HashSet<Coord> coords)
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
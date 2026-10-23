using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

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

    [Puzzle("b2078a7c2a582e68796f55a71f1fe1cd")]
    public int Part1(string input) => Solve(input, 10).EmptyCount;

    [Puzzle("b4b9f7dae4709930cd73d70f45eac0ae")]
    public int Part2(string input) => Solve(input).EndRound;

    public (int EmptyCount, int EndRound) Solve(string input, int rounds = int.MaxValue)
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

            if (targets.Count == 0)
            {
                round++;
                break;
            }

            foreach (var elf in elves.ToList())
            {
                if (!targets.TryGetValue(elf, out var to))
                    continue;

                if (targetCount[to] != 1)
                    continue;
                
                elves.Remove(elf);
                elves.Add(to);
            }

            startDeltaIndex = (startDeltaIndex + 1) % _searchDeltas.Count;
            round++;
        }

        var width = elves.Max(o => o.X) - elves.Min(o => o.X) + 1;
        var height = elves.Max(o => o.Y) - elves.Min(o => o.Y) + 1;
        var emptyCount = width * height - elves.Count;

        return (emptyCount, round);
    }

    private static HashSet<Coord> ParseElves(string input)
    {
        var elves = new HashSet<Coord>();
        var lines = input.Split(LineBreaks.Single);
        for (var y = 0; y < lines.Length; y++)
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

    private bool HasNeighbors(HashSet<Coord> elfs, Coord elf) => 
        _deltas.Any(delta => elfs.Contains(new Coord(elf.X + delta.x, elf.Y + delta.y)));
    
    private readonly List<List<(int x, int y)>> _searchDeltas =
    [
        [North, NorthWest, NorthEast],
        [South, SouthWest, SouthEast],
        [West, NorthWest, SouthWest],
        [East, NorthEast, SouthEast]
    ];

    private readonly List<(int x, int y)> _searchResults =
    [
        North,
        South,
        West,
        East
    ];

    private readonly List<(int x, int y)> _deltas =
    [
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    ];
}
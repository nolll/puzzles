using System.Collections.Immutable;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202224;

public class BlizzardNavigation
{
    private const char Up = '^';
    private const char Right = '>';
    private const char Down = 'v';
    private const char Left = '<';

    private readonly Coord _enter = new(0, 0);
    private readonly Coord _exit = new(0, 0);
    private readonly Dictionary<Coord, IList<Coord>> _neighborCache = new();
    private readonly List<ImmutableHashSet<Coord>> _uniqueBlizzards = new();
    private readonly Grid<char> _grid;

    public BlizzardNavigation(string input)
    {
        _grid = GridBuilder.BuildCharGrid(input);
        var blizzards = new List<Blizzard>();
        var walls = new List<Coord>();
        foreach (var coord in _grid.Coords)
        {
            var value = _grid.ReadValueAt(coord);
            if (coord.Y == _grid.YMin && value == '.')
            {
                _enter = coord;
            }
            else if (coord.Y == _grid.YMax && value == '.')
            {
                _exit = coord;
            }
            else if (value != '#' && value != '.')
            {
                blizzards.Add(new Blizzard(value, coord));
                _grid.WriteValueAt(coord, '.');
            }
            else if (value == '#')
            {
                walls.Add(coord);
            }

            _neighborCache.Add(coord, _grid.OrthogonalAdjacentCoordsTo(coord).ToList());
        }

        var prints = new HashSet<string>();
        while (true)
        {
            var print = PrintMatrix(blizzards);
            if (prints.Contains(print))
                break;

            prints.Add(print);
            var addresses = blizzards.Distinct().Select(o => o.Address).Union(walls);
            var blizzardSet = addresses.ToImmutableHashSet();
            _uniqueBlizzards.Add(blizzardSet);
            blizzards = MoveBlizzards(blizzards);
        }
    }

    public int Part1()
    {
        return CountSteps(_enter, _exit);
    }

    public int Part2()
    {
        var leg1 = CountSteps(_enter, _exit);
        var leg2 = CountSteps(_exit, _enter, leg1);
        var leg3 = CountSteps(_enter, _exit, leg2);
        return leg3;
    }

    private int CountSteps(Coord from, Coord to, int offset = 0)
    {
        var uniqueCount = _uniqueBlizzards.Count;
        var seen = new HashSet<(Coord, int)>();
        var queue = new List<BlizzardCoordCount> { new(from, offset) };
        var index = 0;

        while (index < queue.Count)
        {
            var current = queue[index];
            var nextCount = current.Count + 1;
            var nextState = (nextCount) % uniqueCount;
            var blizzardSet = _uniqueBlizzards[nextState];

            var adjacentCoords = _neighborCache[current.Coord]
                .Where(neighbor => !blizzardSet.Contains(neighbor) && !seen.Contains((neighbor, nextState)))
                .ToList();
            var newCoordCounts = adjacentCoords.Select(o => new BlizzardCoordCount(o, nextCount)).ToList();
            if (!blizzardSet.Contains(current.Coord) && !seen.Contains((current.Coord, nextState)))
                newCoordCounts.Add(new BlizzardCoordCount(current.Coord, nextCount));

            foreach (var coordCount in newCoordCounts)
            {
                queue.Add(coordCount);
                seen.Add((coordCount.Coord, nextState));
            }

            if (newCoordCounts.Any(o => o.Coord.X == to.X && o.Coord.Y == to.Y))
                break;

            index++;
        }

        return queue.FirstOrDefault(o => o.Coord.X == to.X && o.Coord.Y == to.Y)?.Count ?? 0;
    }

    private List<Blizzard> MoveBlizzards(List<Blizzard> blizzards)
    {
        var movedBlizzards = new List<Blizzard>();
        foreach (var blizzard in blizzards)
        {
            var x = blizzard.Address.X;
            var y = blizzard.Address.Y;
            if (blizzard.Direction == Up)
            {
                var newCoord = new Coord(x, y - 1);
                if (newCoord.Y == _grid.YMin) 
                    newCoord = new Coord(x, _grid.YMax - 1);
                movedBlizzards.Add(new Blizzard(blizzard.Direction, newCoord));
            }
            else if (blizzard.Direction == Right)
            {
                var newCoord = new Coord(x + 1, y);
                if (newCoord.X == _grid.XMax) 
                    newCoord = new Coord(1, y);
                movedBlizzards.Add(new Blizzard(blizzard.Direction, newCoord));
            }
            else if (blizzard.Direction == Down)
            {
                var newCoord = new Coord(x, y + 1);
                if (newCoord.Y == _grid.YMax) 
                    newCoord = new Coord(x, 1);
                movedBlizzards.Add(new Blizzard(blizzard.Direction, newCoord));
            }
            else
            {
                var newCoord = new Coord(x - 1, y);
                if (newCoord.X == _grid.XMin) 
                    newCoord = new Coord(_grid.XMax - 1, y);
                movedBlizzards.Add(new Blizzard(blizzard.Direction, newCoord));
            }
        }

        return movedBlizzards;
    }

    private string PrintMatrix(List<Blizzard> blizzards)
    {
        var newMatrix = _grid.Clone();
        foreach (var blizzard in blizzards)
        {
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
}
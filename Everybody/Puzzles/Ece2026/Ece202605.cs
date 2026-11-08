using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Cartograffity")]
[NeedsRewrite]
[Comment("The test for part2 is failing. Real input works though")]
public class Ece202605 : EverybodyEventPuzzle
{
    private const char Land = '#';
    private const char Sand = '=';
    private const char Water = '.';
    private const char Tree = '@';

    [Puzzle("19ac58c224d56c170f9edc4a28c91afe")]
    public int Part1(string input)
    {
        var (land, inputGrid, adjCoords) = CreateGrids(input);
        FillLand(land, inputGrid, adjCoords);
        return land.Values.Count(o => o is Land);
    }

    [Puzzle("630d9ef245287ab209ed01a434c9c846")]
    public int Part2(string input)
    {
        var (land, inputGrid, adjCoords) = CreateGrids(input);
        FillLand(land, inputGrid, adjCoords);
        FillSand(land, adjCoords);
        return land.Values.Count(o => o is Sand);
    }

    [Puzzle("c06950c8357931ab9a5a638fa12a4723")]
    public int Part3(string input)
    {
        var (land, inputGrid, adjCoords) = CreateGrids(input);
        FillLand(land, inputGrid, adjCoords);
        FillSand(land, adjCoords);
        FillTrees(land, adjCoords);
        FillTrees(land, adjCoords);
        return land.Values.Count(o => o is Tree);
    }

    private (Grid<char> land, Grid<char> inputGrid, Dictionary<Coord, Coord[]> adjCoords) CreateGrids(string input)
    {
        var inputGrid = GridBuilder.BuildCharGrid(input);
        var land = new Grid<char>(inputGrid.Width, inputGrid.Height, Water);
        var adjCoords = BuildAdjacentCache(land);
        land.ExtendAllDirections();
        return (land, inputGrid, adjCoords);
    }

    private Dictionary<Coord, Coord[]> BuildAdjacentCache(Grid<char> grid) => 
        grid.Coords.ToDictionary(k => k, v => grid.AllAdjacentCoordsTo(v).ToArray());

    private void FillLand(Grid<char> land, Grid<char> inputGrid, Dictionary<Coord, Coord[]> adjCoords)
    {
        land.WriteValueAt(land.Center, Land);
        var lastLandCount = 0;

        while (lastLandCount != land.Values.Count(o => o is Land))
        {
            lastLandCount = land.Values.Count(o => o is Land);
            var newLand = new HashSet<Coord>();
            var coordsToCheck = inputGrid.Coords.Where(o => adjCoords[o].Any(a => land.ReadValueAt(a) is Land));

            foreach (var coord in coordsToCheck)
            {
                var adjacentCoords = adjCoords[coord];
                var count = adjacentCoords.Count(o => inputGrid.ReadValueAt(o) is '1' || land.ReadValueAt(o) is Land);
                if (count >= 5)
                    newLand.Add(coord);
            }

            land.WriteValueAt(newLand, Land);
        }
    }

    private void FillSand(Grid<char> land, Dictionary<Coord, Coord[]> adjCoords)
    {
        var lastSandCount = 0;

        foreach (var coord in land.Coords)
        {
            if (land.ReadValueAt(coord) is not Land)
                continue;

            var adjacentValues = adjCoords[coord].Select(land.ReadValueAt);
            var count = adjacentValues.Count(o => o is Water);
            if (count >= 1)
                land.WriteValueAt(coord, Sand);
        }

        while (lastSandCount != land.Values.Count(o => o is Sand))
        {
            lastSandCount = land.Values.Count(o => o is Sand);
            var newSand = new HashSet<Coord>();
            var coordsToCheck = land.Coords.Where(o => adjCoords.ContainsKey(o) && adjCoords[o].Any(a => land.ReadValueAt(a) is Sand));

            foreach (var coord in coordsToCheck)
            {
                if (!adjCoords.TryGetValue(coord, out var adjacentCoords))
                    continue;
                var count = adjacentCoords.Count(o => land.ReadValueAt(o) is Sand);
                if (count >= 5)
                    newSand.Add(coord);
            }

            land.WriteValueAt(newSand, Sand);
        }
    }

    private void FillTrees(Grid<char> land, Dictionary<Coord, Coord[]> adjCoords)
    {
        foreach (var coord in land.Coords)
        {
            if (IsTree(land, coord))
                land.WriteValueAt(coord, Tree);
        }

        var newTrees = new HashSet<Coord>();
        foreach (var coord in land.Coords)
        {
            if (CanGrowTree(land, coord, adjCoords))
                newTrees.Add(coord);
        }

        land.WriteValueAt(newTrees, Tree);
    }

    private bool IsTree(Grid<char> land, Coord coord) =>
        land.ReadValueAt(coord) is Land && _treeShape.Select(diff => land.ReadValueAt(coord.Add(diff))).All(v => v is Land or Tree);

    private bool CanGrowTree(Grid<char> land, Coord coord, Dictionary<Coord, Coord[]> adjCoords)
    {
        if (land.ReadValueAt(coord) is not Land)
            return false;

        var adjacentValues = adjCoords[coord].Select(land.ReadValueAt).ToList();
        return adjacentValues.Count(o => o == Tree) >= 4 && adjacentValues.All(o => o is not Water);
    }

    private readonly List<Coord> _treeShape =
    [
        new(-1, -2), new(0, -2), new(1, -2),
        new(-2, -1), new(-1, -1), new(0, -1), new(1, -1), new(2, -1),
        new(-2, 0), new(-1, 0), new(1, 0), new(2, 0),
        new(-2, 1), new(-1, 1), new(0, 1), new(1, 1), new(2, 1),
        new(-1, 2), new(0, 2), new(), new(1, 2),
    ];
}
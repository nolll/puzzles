using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Cartograffity")]
public class Ece202605 : EverybodyEventPuzzle
{
    [Puzzle("19ac58c224d56c170f9edc4a28c91afe")]
    public int Part1(string input)
    {
        var (land, inputGrid) = CreateGrids(input);
        FillLand(land, inputGrid);
        return land.Values.Count(o => o is '#');
    }

    [Puzzle("630d9ef245287ab209ed01a434c9c846")]
    public int Part2(string input)
    {
        var (land, inputGrid) = CreateGrids(input);
        FillLand(land, inputGrid);
        FillSand(land);
        return land.Values.Count(o => o is '=');
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }
    
    private (Grid<char> land, Grid<char> inputGrid) CreateGrids(string input)
    {
        var inputGrid = GridBuilder.BuildCharGrid(input);
        var land = new Grid<char>(inputGrid.Width, inputGrid.Height, '.');
        land.ExtendAllDirections();
        return (land, inputGrid);
    }

    private void FillLand(Grid<char> land, Grid<char> inputGrid)
    {
        land.WriteValueAt(land.Center, '#');
        var lastLandCount = 0;

        while (lastLandCount != land.Values.Count(o => o == '#'))
        {
            lastLandCount = land.Values.Count(o => o == '#');
            var newLand = new HashSet<Coord>();
            var coordsToCheck = inputGrid.Coords.Where(o => land.AllAdjacentValuesTo(o).Any(v => v == '#'));
            
            foreach (var coord in coordsToCheck)
            {
                var adjacentCoords = inputGrid.AllAdjacentCoordsTo(coord);
                var count = adjacentCoords.Count(o => inputGrid.ReadValueAt(o) == '1' || land.ReadValueAt(o) == '#');
                if(count >= 5)
                    newLand.Add(coord);
            }
            
            land.WriteValueAt(newLand, '#');
        }
    }
    
    private void FillSand(Grid<char> land)
    {
        var lastSandCount = 0;

        foreach (var coord in land.Coords)
        {
            if (land.ReadValueAt(coord) != '#')
                continue;
            
            var adjacentValues = land.AllAdjacentValuesTo(coord);
            var count = adjacentValues.Count(o => o == '.');
            if(count >= 1)
                land.WriteValueAt(coord, '=');
        }
        
        while (lastSandCount != land.Values.Count(o => o == '='))
        {
            lastSandCount = land.Values.Count(o => o == '=');
            var newSand = new HashSet<Coord>();
            var coordsToCheck = land.Coords.Where(o => land.AllAdjacentValuesTo(o).Any(v => v == '='));
            
            foreach (var coord in coordsToCheck)
            {
                var adjacentCoords = land.AllAdjacentCoordsTo(coord);
                var count = adjacentCoords.Count(o => land.ReadValueAt(o) == '=');
                if(count >= 5)
                    newSand.Add(coord);
            }
            
            land.WriteValueAt(newSand, '=');
        }
    }
}
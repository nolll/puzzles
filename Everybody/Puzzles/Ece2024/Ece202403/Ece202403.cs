using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202403;

[Name("Mining Maestro")]
public class Ece202403 : EverybodyEventPuzzle
{
    private enum SlopeRule
    {
        Orthogonal,
        Diagonal
    }
    
    [Puzzle("f8809d3064586fdc87c819e0caa76093")]
    public int Part1(string input) => Solve(input, SlopeRule.Orthogonal);

    [Puzzle("d6f8a8bfba935c69e51e8d3249dc7264")]
    public int Part2(string input) => Solve(input, SlopeRule.Orthogonal);

    [Puzzle("b37fb7a9a2f7e97880544e19b5c4e323")]
    public int Part3(string input) => Solve(input, SlopeRule.Diagonal);

    private static int Solve(string input, SlopeRule slopeRule)
    {
        var charGrid = GridBuilder.BuildCharGrid(input);
        var grid = new Grid<int>(charGrid.Width, charGrid.Height);
        var coords = new List<Coord>();
        var digLevel = 1;
        
        foreach (var coord in charGrid.Coords)
        {
            if (charGrid.ReadValueAt(coord) == '#')
            {
                coords.Add(coord);
                grid.WriteValueAt(coord, digLevel);
            }
        }

        var requiredNeighbors = slopeRule == SlopeRule.Diagonal ? 8 : 4;
        
        while (coords.Count > 0)
        {
            var nextCoords = new List<Coord>();
            foreach (var coord in coords)
            {
                var neighbors = slopeRule == SlopeRule.Diagonal
                    ? grid.AllAdjacentValuesTo(coord)
                    : grid.OrthogonalAdjacentValuesTo(coord);
                
                if (neighbors.Count == requiredNeighbors && neighbors.All(o => o >= digLevel))
                {
                    grid.WriteValueAt(coord, digLevel + 1);
                    nextCoords.Add(coord);
                }
            }
            digLevel++;
            coords = nextCoords;
        }
        
        return grid.Values.Sum();
    }
}
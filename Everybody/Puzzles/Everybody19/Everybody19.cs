using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody19;

[Name("Encrypted Duck")]
public class Everybody19 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var result = Part1And2(input, 1);
        return new PuzzleResult(result, "d9c02c79770322919192525a442c576d");
    }

    public PuzzleResult Part2(string input)
    {
        var result = Part1And2(input, 100);
        return new PuzzleResult(result, "81f686ab8d66b6fc14b37f46ec85d6f2");
    }

    private string Part1And2(string input, int repetitionCount)
    {
        var (directions, hiddenMessage) = input.Split(LineBreaks.Double);
        var grid = MatrixBuilder.BuildCharMatrix(hiddenMessage);
        (int dx, int dy)[] coordDeltas = [(0, -1), (1, -1), (1, 0), (1, 1), (0, 1), (-1, 1), (-1, 0), (-1, -1)];
        
        for (var r = 0; r < repetitionCount; r++)
        {
            var directionIndex = 0;
            foreach (var coord in grid.Coords)
            {
                grid.MoveTo(coord);
            
                if(grid.IsAtEdge)
                    continue;
            
                var adjacentCoords = coordDeltas
                    .Select(o => new MatrixAddress(grid.Address.X + o.dx, grid.Address.Y + o.dy)).ToArray();
                var chars = string.Join("", adjacentCoords.Select(o => grid.ReadValueAt(o)));
                var direction = directions[directionIndex % directions.Length];
                var delta = direction == 'L' ? -1 : 1;
            
                for (var i = 0; i < adjacentCoords.Length; i++)
                {
                    var index = (i + delta + adjacentCoords.Length) % adjacentCoords.Length;
                    grid.WriteValueAt(adjacentCoords[index], chars[i]);
                }

                directionIndex++;
            }
        }

        var print = grid.Print().Replace(LineBreaks.Single, "");
        var start = print.IndexOf('>') + 1;
        var length = print.IndexOf('<') - start;
        return print.Substring(start, length);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}
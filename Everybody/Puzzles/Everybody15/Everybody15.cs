using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Graphs;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody15;

[Name("From the Herbalist's Diary")]
public class Everybody15 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var start = new MatrixAddress(input.Split(LineBreaks.Single).First().IndexOf('.'), 0);
        var targets = matrix.FindAddresses('H');

        var inputs = new List<Graph.Input>();
        foreach (var coord in matrix.Coords)
        {
            if (matrix.ReadValueAt(coord) == '#')
                continue;

            var nbrs = matrix.OrthogonalAdjacentCoordsTo(coord);
            foreach (var nbr in nbrs)
            {
                if (matrix.ReadValueAt(nbr) != '#')
                {
                    inputs.Add(new Graph.Input(coord.Id, nbr.Id));
                    inputs.Add(new Graph.Input(nbr.Id, coord.Id));
                }
            }
        }

        var cost = Graph.GetLowestCost(inputs, start.Id, targets.Select(o => o.Id).ToList()) * 2;
        
        return new PuzzleResult(cost, "4d832f8cc35ae0da374a91187caa538b");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}
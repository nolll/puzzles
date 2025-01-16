using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Everybody.Puzzles.Everybody18;

[Name("")]
public class Everybody18 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var time = Part1And2(input);
        return new PuzzleResult(time, "58a8744a3bef1c6dcbf739d171b22ea5");
    }

    public PuzzleResult Part2(string input)
    {
        var time = Part1And2(input);
        return new PuzzleResult(time, "e709ebaa41c12566e0524c796fac3615");
    }

    private int Part1And2(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var palmtrees = matrix.FindAddresses('P');
        HashSet<MatrixAddress> current = matrix.Coords.Where(o => (o.X == 0 || o.X == matrix.XMax) && matrix.ReadValueAt(o) == '.')
            .ToHashSet();
        var reached = new HashSet<MatrixAddress>();
        var time = 0;
        while (reached.Count < palmtrees.Count)
        {
            var next = new HashSet<MatrixAddress>();
            foreach (var c in current)
            {
                var adjacent = matrix.OrthogonalAdjacentCoordsTo(c);
                foreach (var adj in adjacent)
                {
                    var v = matrix.ReadValueAt(adj); 
                    if (v != '#') 
                        next.Add(adj);
                    
                    if (matrix.ReadValueAt(adj) == 'P') 
                        reached.Add(adj);
                }
            }

            current = next;
            
            time++;
        }

        return time;
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}
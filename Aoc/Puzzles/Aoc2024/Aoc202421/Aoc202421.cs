using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Graphs;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202421;

[Name("Keypad Conundrum")]
public class Aoc202421 : AocPuzzle
{
    private string _robot1Pos = "A";
    private string _robot2Pos = "A";
    private string _robot3Pos = "A";

    private const string NumKeys = """
                                   789
                                   456
                                   123
                                   .0A
                                   """;

    private const string ArrowKeys = """
                                     .^A
                                     <v>
                                     """;

    private static readonly Dictionary<(string, string), char> NumDirections = BuildNumDirections(NumKeys);
    private static readonly Dictionary<(string, string), char> ArrowDirections = BuildNumDirections(ArrowKeys);
    private static readonly List<Graph.Input> NumpadInputs = GetNumpadInputs();
    private static readonly List<Graph.Input> ArrowpadInputs = GetArrowpadInputs();

    private static List<Graph.Input> GetNumpadInputs()
    {
        var matrix = MatrixBuilder.BuildCharMatrix(NumKeys);
        var inputs = new List<Graph.Input>();
        
        foreach (var coord in matrix.Coords)
        {
            var v = matrix.ReadValueAt(coord);
            var adj = matrix.OrthogonalAdjacentValuesTo(coord).Where(o => o != '.');
            inputs.AddRange(adj.Select(adjv => new Graph.Input(v.ToString(), adjv.ToString())));
        }
        
        return inputs;
    }

    private static List<Graph.Input> GetArrowpadInputs()
    {
        var matrix = MatrixBuilder.BuildCharMatrix(ArrowKeys);
        var inputs = new List<Graph.Input>();
        
        foreach (var coord in matrix.Coords)
        {
            var v = matrix.ReadValueAt(coord);
            var adj = matrix.OrthogonalAdjacentValuesTo(coord).Where(o => o != '.');
            inputs.AddRange(adj.Select(adjv => new Graph.Input(v.ToString(), adjv.ToString())));
        }
        
        return inputs;
    }

    private string GetDirectionsLevel1(string input)
    {
        var directions = "";
        foreach (var c in input)
        {
            var to = c.ToString();
            var result = Graph.GetShortestPath(NumpadInputs, _robot1Pos, to);
            var path = string.Join("", result.path);
            directions += GetDirectionsLevel2(GetNumDirections(path) + "A");
            _robot1Pos = to;
        }

        return directions;
    }
    
    private string GetDirectionsLevel2(string input)
    {
        var directions = "";
        foreach (var c in input)
        {
            var to = c.ToString();
            var result = Graph.GetShortestPath(ArrowpadInputs, _robot2Pos, to);
            var path = string.Join("", result.path);
            directions += GetDirectionsLevel3(GetArrowDirections(path) + "A");
            _robot2Pos = to;
        }

        return directions;
    }
    
    private string GetDirectionsLevel3(string input)
    {
        var directions = "";
        foreach (var c in input)
        {
            var to = c.ToString();
            var result = Graph.GetShortestPath(ArrowpadInputs, _robot3Pos, to);
            var path = string.Join("", result.path);
            directions += GetArrowDirections(path) + "A";
            _robot3Pos = to;
        }

        return directions;
    }
    
    public PuzzleResult Part1(string input)
    {
        var directions = GetDirectionsLevel1(input);
        
        return new PuzzleResult(directions);
    }

    private string GetNumDirections(string path)
    {
        var dirs = "";
        for (var i = 0; i < path.Length - 1; i++)
        {
            var from = path[i].ToString();
            var to = path[i + 1].ToString();
            dirs += NumDirections[(from, to)];
        }
        
        return dirs;
    }
    
    private string GetArrowDirections(string path)
    {
        var dirs = "";
        for (var i = 0; i < path.Length - 1; i++)
        {
            var from = path[i].ToString();
            var to = path[i + 1].ToString();
            dirs += ArrowDirections[(from, to)];
        }
        
        return dirs;
    }

    private static Dictionary<(string, string), char> BuildNumDirections(string layout)
    {
        var directions = new Dictionary<(string, string), char>();
        var matrix = MatrixBuilder.BuildCharMatrix(layout);
        foreach (var coord in matrix.Coords)
        {
            matrix.MoveTo(coord);
            var from = matrix.ReadValue().ToString();
            if (from == ".")
                continue;
            
            for (var i = 0; i < 4; i++)
            {
                matrix.TurnRight();
                if (matrix.TryMoveForward())
                {
                    var to = matrix.ReadValue().ToString();
                    if (to != "." && to != from)
                    {
                        directions.Add((from, to), GetDirection(matrix.Direction));
                    }
                    
                    matrix.MoveBackward();
                }
            }
        }

        return directions;
    }

    private static char GetDirection(MatrixDirection dir)
    {
        if (dir.Equals(MatrixDirection.Up))
            return '^';
        if (dir.Equals(MatrixDirection.Right))
            return '>';
        if (dir.Equals(MatrixDirection.Down))
            return 'v';
        return '<';
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }
}
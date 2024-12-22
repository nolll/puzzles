using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202420;

[Name("Race Condition")]
public class Aoc202420 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var result = CountCheatsBetterThanPart1(input, 100);
        
        return new PuzzleResult(result, "345ad458eb8fecd2bee1b07cda111f5b");
    }

    public PuzzleResult Part2(string input)
    {
        var result = CountCheatsBetterThan(input, 100, 20);
        
        return new PuzzleResult(0);
    }

    public int CountCheatsBetterThan(string input, int limit, int cheatCount)
    {
        var results = ScoresWithCheats(input, cheatCount);
        return results.paths.Count(o => results.baseScore - o.Count >= limit);
    }
    
    public int CountCheatsBetterThanPart1(string input, int limit)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var start = matrix.FindAddresses('S').First();
        var end = matrix.FindAddresses('E').First();
        matrix.WriteValueAt(start, '.');
        matrix.WriteValueAt(end, '.');
        
        var path = PathFinder.ShortestPathTo(matrix, start, end);
        path = [start, ..path];

        var distanceToTarget = new Dictionary<MatrixAddress, int>();
        for (var i = 0; i < path.Count; i++)
        {
            distanceToTarget.Add(path[i], path.Count - i);
        }

        var cheats = new List<int>();
        foreach (var coord in path)
        {
            matrix.MoveTo(coord);
            matrix.TurnTo(MatrixDirection.Up);
            for (var i = 0; i < 4; i++)
            {
                matrix.TurnRight();
                if (!matrix.TryMoveForward())
                    continue;

                if(matrix.ReadValue() == '.')
                {
                    matrix.MoveBackward();
                    continue;
                }

                if (!matrix.MoveForward())
                    continue;
                
                if(matrix.ReadValue() == '.')
                {
                    var diff = distanceToTarget[coord] - distanceToTarget[matrix.Address];
                    if(diff > 0)
                        cheats.Add(diff);
                }

                matrix.MoveBackward();
                matrix.MoveBackward();
            }
        }

        return cheats.Count(o => o > limit);
    }
    
    public (int baseScore, List<List<MatrixAddress>> paths) ScoresWithCheats(string input, int cheatCount)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var start = matrix.FindAddresses('S').First();
        var end = matrix.FindAddresses('E').First();
        matrix.WriteValueAt(start, '.');
        matrix.WriteValueAt(end, '.');

        var path = PathFinder.ShortestPathTo(matrix, start, end);
        path = [start, ..path];
        
        var precalc = new Dictionary<MatrixAddress, List<MatrixAddress>>();
        for (var i = 0; i < path.Count; i++)
        {
            var c = path[i];
            precalc.Add(c, path.Skip(i + 1).ToList());
        }
        
        var cheatPaths = new List<List<MatrixAddress>>();
        for (var i = 0; i < path.Count; i++)
        {
            if (i % 100 == 0)
            {
                Console.WriteLine();
                Console.WriteLine($"{i} of {path.Count}");
            }

            var coord = path[i];
            var cheatStarts = matrix.OrthogonalAdjacentCoordsTo(coord).Where(o => matrix.ReadValueAt(o) == '#');
            foreach (var cs in cheatStarts)
            {
                var cheatPath = Bfs(matrix, cs, end, cheatCount - 1, precalc);
                List<MatrixAddress> fullPath = [..path.Skip(1).Take(i), ..cheatPath];
                cheatPaths.Add(fullPath);
            }
        }

        return (path.Count, cheatPaths);
    }

    public List<List<MatrixAddress>> CheatOne(string input, int cheatIndex)
    {
        const int cheatCount = 2;
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var start = matrix.FindAddresses('S').First();
        var end = matrix.FindAddresses('E').First();
        matrix.WriteValueAt(start, '.');
        matrix.WriteValueAt(end, '.');

        var path = PathFinder.ShortestPathTo(matrix, start, end);
        path = [start, ..path];
        
        var precalc = new Dictionary<MatrixAddress, List<MatrixAddress>>();
        for (var i = 0; i < path.Count; i++)
        {
            var c = path[i];
            precalc.Add(c, path.Skip(i + 1).ToList());
        }
        
        var cheatPaths = new List<List<MatrixAddress>>();
        var coord = path[cheatIndex];
        var cheatStarts = matrix.OrthogonalAdjacentCoordsTo(coord).Where(o => matrix.ReadValueAt(o) == '#');
        var newPaths = new List<List<MatrixAddress>>();
        foreach (var cs in cheatStarts)
        {
            var cheatPath = Bfs(matrix, cs, end, cheatCount - 1, precalc);
            List<MatrixAddress> fullPath = [..path.Skip(1).Take(cheatIndex), ..cheatPath];
            newPaths.Add(fullPath);
        }
        cheatPaths.AddRange(newPaths);
        
        return cheatPaths;
    }
    
    private List<MatrixAddress> Bfs(
        Matrix<char> matrix, 
        MatrixAddress start, 
        MatrixAddress end, 
        int cheatCount,
        Dictionary<MatrixAddress, List<MatrixAddress>> precalc)
    {
        var queue = new Queue<State>();
        var visited = new HashSet<MatrixAddress>();
        queue.Enqueue(new State(start, [], cheatCount - 1));

        while (queue.Count > 0)
        {
            var state = queue.Dequeue();
            var path = state.Path;
            var node = state.Coord;

            path = [..path, node];
            visited.Add(node);
            
            if (state.CheatStepsLeft == 0 && matrix.ReadValueAt(node) == '.' && path.Count + precalc.Count < precalc[node].Count)
            {
                List<MatrixAddress> ret = [..path, ..precalc[node].SkipLast(1)];
                return ret;
            }

            if (node.Equals(end))
                return path;

            var adjNodes = matrix.OrthogonalAdjacentCoordsTo(node);
            if (state.CheatStepsLeft == 0)
                adjNodes = adjNodes.Where(o => matrix.ReadValueAt(o) == '.').ToList();

            foreach (var adj in adjNodes)
            {
                if (!visited.Contains(adj))
                {
                    if(state.CheatStepsLeft > 0 && matrix.ReadValueAt(adj) == '#')
                        queue.Enqueue(new State(adj, path.ToList(), state.CheatStepsLeft - 1));
                    
                    if(matrix.ReadValueAt(adj) == '.')
                        queue.Enqueue(new State(adj, path.ToList(), 0));
                }
            }
        }

        return [];
    }

    private class State(MatrixAddress coord, List<MatrixAddress> path, int cheatStepsLeft)
    {
        public MatrixAddress Coord { get; } = coord;
        public List<MatrixAddress> Path { get; } = path;
        public int CheatStepsLeft { get; } = cheatStepsLeft;
    }
}
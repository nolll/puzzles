using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202420;

// Thanks to Alex Prosser
[Name("Gliding Finale")]
public class Ece202420 : EverybodyEventPuzzle
{
    private readonly Dictionary<char, GridDirection[]> _nextDirections = new()
    {
        { GridDirection.Up.Name, [GridDirection.Left, GridDirection.Up, GridDirection.Right] },
        { GridDirection.Right.Name, [GridDirection.Up, GridDirection.Right, GridDirection.Down] },
        { GridDirection.Down.Name, [GridDirection.Right, GridDirection.Down, GridDirection.Left] },
        { GridDirection.Left.Name, [GridDirection.Down, GridDirection.Left, GridDirection.Up] }
    };

    private readonly Dictionary<char, int> _changes = new()
    {
        { '.', -1 },
        { 'A', -1 },
        { 'B', -1 },
        { 'C', -1 },
        { '-', -2 },
        { '+', 1 }
    };

    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var s = grid.FindAddresses('S').First();
        grid.WriteValueAt(s, '.');
        var states = GridDirection.All.ToDictionary(k => (s.X, s.Y, k.Name), _ => 1000);

        for (var i = 0; i < 100; i++)
        {
            var next = new Dictionary<(int x, int y, char dir), int>();
            foreach (var state in states)
            {
                var (x, y, dir) = state.Key;
                var score = state.Value;
                grid.MoveTo(x, y);
                grid.TurnTo(GridDirection.Get(dir));
                foreach (var nextdir in _nextDirections[dir])
                {
                    grid.TurnTo(nextdir);
                    if (grid.TryMoveForward())
                    {
                        var v = grid.ReadValue();
                        if (v != '#')
                        {
                            var newScore = score + _changes[grid.ReadValue()];
                            var key = (grid.Address.X, grid.Address.Y, grid.Direction.Name);
                            if (next.TryGetValue(key, out var prevScore))
                                next[key] = Math.Max(newScore, prevScore);
                            else
                                next[key] = newScore;
                        }
                            
                        grid.MoveBackward();
                    }
                }
            }

            states = next;
        }

        var result = states.Values.Max();
        return new PuzzleResult(result, "ad1b597677b7daffac4e3c11d973c8be");
    }

    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var s = grid.FindAddresses('S').First();
        grid.WriteValueAt(s, '.');
        var states = GridDirection.All.ToDictionary(k => (s.X, s.Y, k.Name, ' '), _ => 10000);
        var time = 0;
        var found = false;
        
        while (!found)
        {
            time++;
            var next = new Dictionary<(int x, int y, char dir, char checkpoint), int>();
            foreach (var state in states)
            {
                var (x, y, dir, checkpoint) = state.Key;
                var score = state.Value;
                grid.MoveTo(x, y);
                grid.TurnTo(GridDirection.Get(dir));
                foreach (var nextdir in _nextDirections[dir])
                {
                    grid.TurnTo(nextdir);
                    if (grid.TryMoveForward())
                    {
                        var v = grid.ReadValue();
                        if (v != '#')
                        {
                            var newCheckpoint = checkpoint == ' ' && v == 'A' || 
                                                checkpoint == 'A' && v == 'B' || 
                                                checkpoint == 'B' && v == 'C'
                                ? v
                                : checkpoint;
                            var newScore = score + _changes[grid.ReadValue()];
                            if (newScore >= 10000 && grid.Address.X == s.X && grid.Address.Y == s.Y && newCheckpoint == 'C')
                                found = true;
                            var key = (grid.Address.X, grid.Address.Y, grid.Direction.Name, newCheckpoint);
                            if (next.TryGetValue(key, out var prevScore))
                                next[key] = Math.Max(newScore, prevScore);
                            else
                                next[key] = newScore;
                        }
                            
                        grid.MoveBackward();
                    }
                }
            }
            
            states = next;
        }
        
        return new PuzzleResult(time, "455f69d24dffb75a22302c1cbad1475b");
    }

    public PuzzleResult Part3(string input)
    {
        var result = RunPart3(input, -3);
        return new PuzzleResult(result, "f410a855e124b277c01cf1caebd9778e");
    }

    // The best col was obvious. 4 cols to the right for the test input and three steps to the right for the real input
    public static int RunPart3(string input, int stepsToGoodCol)
    {
        var changes = new Dictionary<char, int>
        {
            { '.', -1 },
            { '-', -2 },
            { '+', 1 }
        };

        var grid = input.Split(LineBreaks.Single).Select(line => line.ToCharArray()).ToArray();
        var width = grid[0].Length;
        var height = grid.Length;
        
        var start = (x: 0, y: 0);
        for (var y = 0; y < height; y++) {
            for (var x = 0; x < width; x++) {
                if (grid[y][x] == 'S') {
                    start = (x, y);
                    grid[y][x] = '.';
                }
            }
        }
        
        var altitude = 384400;
        var distance = 0;
        var rightMovement = stepsToGoodCol;
        while (altitude > 0) {
            if (rightMovement != 0) {
                start.x += Math.Sign(stepsToGoodCol);
                rightMovement += -Math.Sign(stepsToGoodCol);
            } else {
                start.y = (start.y + 1) % height;
                distance++;
            }

            altitude += changes[grid[start.y][start.x]];
        }

        return distance;
    }
}
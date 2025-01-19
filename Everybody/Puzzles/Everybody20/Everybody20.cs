using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Everybody.Puzzles.Everybody20;

// Thanks to Alex Prosser
[Name("Gliding Finale")]
public class Everybody20 : EverybodyPuzzle
{
    private readonly Dictionary<char, MatrixDirection[]> _nextDirections = new()
    {
        { MatrixDirection.Up.Name, [MatrixDirection.Left, MatrixDirection.Up, MatrixDirection.Right] },
        { MatrixDirection.Right.Name, [MatrixDirection.Up, MatrixDirection.Right, MatrixDirection.Down] },
        { MatrixDirection.Down.Name, [MatrixDirection.Right, MatrixDirection.Down, MatrixDirection.Left] },
        { MatrixDirection.Left.Name, [MatrixDirection.Down, MatrixDirection.Left, MatrixDirection.Up] }
    };

    private readonly Dictionary<char, int> _changes = new()
    {
        { '.', -1 },
        { '-', -2 },
        { '+', 1 }
    };

    public PuzzleResult Part1(string input)
    {
        var grid = MatrixBuilder.BuildCharMatrix(input);
        var s = grid.FindAddresses('S').First();
        grid.WriteValueAt(s, '.');

        var states = new Dictionary<(int x, int y, char dir), int>
        {
            { (s.X, s.Y, MatrixDirection.Up.Name), 1000 },
            { (s.X, s.Y, MatrixDirection.Right.Name), 1000 },
            { (s.X, s.Y, MatrixDirection.Down.Name), 1000 },
            { (s.X, s.Y, MatrixDirection.Left.Name), 1000 }
        };

        for (var i = 0; i < 100; i++)
        {
            var next = new Dictionary<(int x, int y, char dir), int>();
            foreach (var state in states)
            {
                var (x, y, dir) = state.Key;
                var score = state.Value;
                grid.MoveTo(x, y);
                grid.TurnTo(MatrixDirection.Get(dir));
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
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}
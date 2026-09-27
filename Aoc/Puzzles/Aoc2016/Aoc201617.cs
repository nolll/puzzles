using Pzl.Common;
using Pzl.Tools.Cryptography;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Two Steps Forward")]
public class Aoc201617 : AocPuzzle
{
    [Puzzle("145f734762c2ff3fc7d2661d011be656")]
    public string Part1(string input)
    {
        var maze = new LockedDoorMaze();
        maze.FindPaths(input);
        return maze.ShortestPath ?? "";
    }

    [Puzzle("0926372f3b51236a2e58ce27bc97d696")]
    public int Part2(string input)
    {
        var maze = new LockedDoorMaze();
        maze.FindPaths(input);
        return maze.LongestPath?.Length ?? 0;
    }

    public class LockedDoorMaze
    {
        private readonly HashFactory _hashFactory;
        private readonly Coord _target;

        public string? ShortestPath { get; private set; }
        public string? LongestPath { get; private set; }

        public LockedDoorMaze()
        {
            _hashFactory = new HashFactory();
            _target = new Coord(3, 3);
        }

        public void FindPaths(string passcode)
        {
            var finishedPaths = new List<MazeStep>();
            var openPaths = new List<MazeStep> { new MazeStep(new Coord(0, 0), "") };
            while (openPaths.Any())
            {
                var current = openPaths.First();
                openPaths.RemoveAt(0);

                if (current.Address.Equals(_target))
                {
                    finishedPaths.Add(current);
                    continue;
                }

                var hash = _hashFactory.StringHash(passcode + current.Path).Substring(0, 4);
                var x = current.Address.X;
                var y = current.Address.Y;

                if (CanMoveUp(current.Address, hash))
                    openPaths.Add(new MazeStep(new Coord(x, y - 1), current.Path + 'U'));
                if (CanMoveDown(current.Address, hash))
                    openPaths.Add(new MazeStep(new Coord(x, y + 1), current.Path + 'D'));
                if (CanMoveLeft(current.Address, hash))
                    openPaths.Add(new MazeStep(new Coord(x - 1, y), current.Path + 'L'));
                if (CanMoveRight(current.Address, hash))
                    openPaths.Add(new MazeStep(new Coord(x + 1, y), current.Path + 'R'));
            }

            ShortestPath = finishedPaths.OrderBy(o => o.Path.Length).First().Path;
            LongestPath = finishedPaths.OrderByDescending(o => o.Path.Length).First().Path;
        }

        private bool CanMoveUp(Coord currentAddress, string hash) => currentAddress.Y > 0 && CanMove(hash[0]);
        private bool CanMoveDown(Coord currentAddress, string hash) => currentAddress.Y < _target.Y && CanMove(hash[1]);
        private bool CanMoveLeft(Coord currentAddress, string hash) => currentAddress.X > 0 && CanMove(hash[2]);
        private bool CanMoveRight(Coord currentAddress, string hash) => currentAddress.X < _target.X && CanMove(hash[3]);
        private bool CanMove(char c) => c > 'a';
    }

    public record MazeStep(Coord Address, string Path);
}
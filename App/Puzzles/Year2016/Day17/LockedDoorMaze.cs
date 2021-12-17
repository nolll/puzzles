using System.Collections.Generic;
using System.Linq;
using App.Common.CoordinateSystems;
using App.Common.Hashing;

namespace App.Puzzles.Year2016.Day17;

public class LockedDoorMaze
{
    private readonly Hashfactory _hashFactory;
    private readonly MatrixAddress _target;

    public string ShortestPath { get; private set; }
    public string LongestPath { get; private set; }

    public LockedDoorMaze()
    {
        _hashFactory = new Hashfactory();
        _target = new MatrixAddress(3, 3);
    }

    public void FindPaths(string passcode)
    {
        var finishedPaths = new List<MazeStep>();
        var openPaths = new List<MazeStep> { new MazeStep(new MatrixAddress(0, 0), "") };
        while (openPaths.Any())
        {
            var current = openPaths.First();
            openPaths.RemoveAt(0);
                
            if (current.Address.Equals(_target))
            {
                finishedPaths.Add(current);
                continue;
            }

            var hash = _hashFactory.StringHashFromString(passcode + current.Path).Substring(0, 4);
            var x = current.Address.X;
            var y = current.Address.Y;

            if (CanMoveUp(current.Address, hash))
                openPaths.Add(new MazeStep(new MatrixAddress(x, y - 1), current.Path + 'U'));
            if (CanMoveDown(current.Address, hash))
                openPaths.Add(new MazeStep(new MatrixAddress(x, y + 1), current.Path + 'D'));
            if (CanMoveLeft(current.Address, hash))
                openPaths.Add(new MazeStep(new MatrixAddress(x - 1, y), current.Path + 'L'));
            if (CanMoveRight(current.Address, hash))
                openPaths.Add(new MazeStep(new MatrixAddress(x + 1, y), current.Path + 'R'));
        }

        ShortestPath = finishedPaths.OrderBy(o => o.Path.Length).First().Path;
        LongestPath = finishedPaths.OrderByDescending(o => o.Path.Length).First().Path;
    }

    private bool CanMoveUp(MatrixAddress currentAddress, string hash) => currentAddress.Y > 0 && CanMove(hash[0]);
    private bool CanMoveDown(MatrixAddress currentAddress, string hash) => currentAddress.Y < _target.Y && CanMove(hash[1]);
    private bool CanMoveLeft(MatrixAddress currentAddress, string hash) => currentAddress.X > 0 && CanMove(hash[2]);
    private bool CanMoveRight(MatrixAddress currentAddress, string hash) => currentAddress.X < _target.X && CanMove(hash[3]);
    private bool CanMove(char c) => c > 'a';
}
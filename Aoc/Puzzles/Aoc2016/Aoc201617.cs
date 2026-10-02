using Pzl.Common;
using Pzl.Tools.Cryptography;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Two Steps Forward")]
public class Aoc201617 : AocPuzzle
{
    [Puzzle("145f734762c2ff3fc7d2661d011be656")]
    public string Part1(string input) => GetFinishedPaths(input).MinBy(o => o.Path.Length)!.Path;

    [Puzzle("0926372f3b51236a2e58ce27bc97d696")]
    public int Part2(string input) => GetFinishedPaths(input).Max(o => o.Path.Length);

    private static List<MazeStep> GetFinishedPaths(string passcode)
    {
        var target = new Coord(3, 3);
        var hashFactory = new HashFactory();
        var finishedPaths = new List<MazeStep>();
        var openPaths = new List<MazeStep> { new(new Coord(0, 0), "") };
        while (openPaths.Any())
        {
            var current = openPaths.First();
            openPaths.RemoveAt(0);

            if (current.Address.Equals(target))
            {
                finishedPaths.Add(current);
                continue;
            }

            var hash = hashFactory.StringHash(passcode + current.Path)[..4];
            var (x, y) = current.Address;

            if (CanMoveUp(current.Address, hash))
                openPaths.Add(new MazeStep(new Coord(x, y - 1), current.Path + 'U'));
            if (CanMoveDown(current.Address, target, hash))
                openPaths.Add(new MazeStep(new Coord(x, y + 1), current.Path + 'D'));
            if (CanMoveLeft(current.Address, hash))
                openPaths.Add(new MazeStep(new Coord(x - 1, y), current.Path + 'L'));
            if (CanMoveRight(current.Address, target, hash))
                openPaths.Add(new MazeStep(new Coord(x + 1, y), current.Path + 'R'));
        }
            
        return finishedPaths;
    }

    private static bool CanMoveUp(Coord currentAddress, string hash) => currentAddress.Y > 0 && CanMove(hash[0]);
    private static bool CanMoveDown(Coord currentAddress, Coord target, string hash) => currentAddress.Y < target.Y && CanMove(hash[1]);
    private static bool CanMoveLeft(Coord currentAddress, string hash) => currentAddress.X > 0 && CanMove(hash[2]);
    private static bool CanMoveRight(Coord currentAddress, Coord target, string hash) => currentAddress.X < target.X && CanMove(hash[3]);
    private static bool CanMove(char c) => c > 'a';

    public record MazeStep(Coord Address, string Path);
}
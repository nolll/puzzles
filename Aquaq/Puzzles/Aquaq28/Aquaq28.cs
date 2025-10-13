using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq28;

[Name("Hall of Mirrors")]
public class Aquaq28 : AquaqPuzzle
{
    private const char MirrorLeft = '\\';
    private const char MirrorRight = '/';
    private const char Empty = ' ';
    private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_0123456789";

    public PuzzleResult Run(string input)
    {
        var result = Encrypt(input, "FISSION_MAILED");

        return new PuzzleResult(result, "b2f9a54afc1e88e86671425bfc4e48b4");
    }

    public static string Encrypt(string input, string word)
    {
        var lines = StringReader.ReadLines(input)
            .Skip(1).SkipLast(1)
            .Select(o => o.Substring(1, o.Length - 2));
        var gridInput = string.Join(LineBreaks.Single, lines);

        var grid = GridBuilder.BuildCharGridWithoutTrim(gridInput, Empty);

        var encrypted = string.Empty;
        foreach (var c in word)
        {
            var startPos = new Coord(0, Characters.IndexOf(c));
            grid.MoveTo(startPos);
            grid.FaceRight();

            while (true)
            {
                var v = grid.ReadValue();

                if (v == MirrorLeft)
                {
                    if (IsMovingHorizontally(grid))
                        grid.TurnRight();
                    else
                        grid.TurnLeft();

                    grid.WriteValue(MirrorRight);
                }
                else if(v == MirrorRight)
                {
                    if (IsMovingHorizontally(grid))
                        grid.TurnLeft();
                    else
                        grid.TurnRight();
                    grid.WriteValue(MirrorLeft);
                }

                if (!grid.TryMoveForward())
                    break;
            }

            encrypted += grid.IsAtBottomEdge || grid.IsAtTopEdge
                ? Characters[grid.Coord.X]
                : Characters[grid.Coord.Y];
        }

        return encrypted;
    }

    private static bool IsMovingHorizontally(Grid<char> grid) 
        => grid.Direction.Equals(GridDirection.Right) || grid.Direction.Equals(GridDirection.Left);
}
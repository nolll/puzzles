using Common.CoordinateSystems.CoordinateSystem2D;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq28;

public class Aquaq28 : AquaqPuzzle
{
    private const char MirrorLeft = '\\';
    private const char MirrorRight = '/';
    private const char Empty = ' ';
    private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_0123456789";

    public override string Name => "Hall of Mirrors";

    protected override PuzzleResult Run()
    {
        var result = Encrypt(InputFile, "FISSION_MAILED");

        return new PuzzleResult(result, null, "b2f9a54afc1e88e86671425bfc4e48b4");
    }

    public static string Encrypt(string input, string word)
    {
        var lines = input.Split(Environment.NewLine)
            .Skip(1).SkipLast(1)
            .Select(o => o.Substring(1, o.Length - 2));
        var matrixInput = string.Join(Environment.NewLine, lines);

        var matrix = MatrixBuilder.BuildCharMatrixWithoutTrim(matrixInput, Empty);

        var encrypted = string.Empty;
        foreach (var c in word)
        {
            var startPos = new MatrixAddress(0, Characters.IndexOf(c));
            matrix.MoveTo(startPos);
            matrix.FaceRight();

            while (true)
            {
                var v = matrix.ReadValue();

                if (v == MirrorLeft)
                {
                    if (IsMovingHorizontally(matrix))
                        matrix.TurnRight();
                    else
                        matrix.TurnLeft();

                    matrix.WriteValue(MirrorRight);
                }
                else if(v == MirrorRight)
                {
                    if (IsMovingHorizontally(matrix))
                        matrix.TurnLeft();
                    else
                        matrix.TurnRight();
                    matrix.WriteValue(MirrorLeft);
                }

                if (!matrix.TryMoveForward())
                    break;
            }

            encrypted += matrix.IsAtBottom || matrix.IsAtTop
                ? Characters[matrix.Address.X]
                : Characters[matrix.Address.Y];
        }

        return encrypted;
    }

    private static bool IsMovingHorizontally(Matrix<char> matrix) 
        => matrix.Direction.Equals(MatrixDirection.Right) || matrix.Direction.Equals(MatrixDirection.Left);
}
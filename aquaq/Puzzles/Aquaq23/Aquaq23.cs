using Common.CoordinateSystems.CoordinateSystem2D;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq23;

public class Aquaq23 : AquaqPuzzle
{
    private static string Alphabet => "abcdefghijklmnopqrstuvwxyz";
    private static char[] _cipherAlphabet = Alphabet.ToCharArray().Where(o => o != 'j').ToArray();

    public override string Name => "Fair Play";

    protected override PuzzleResult Run()
    {
        throw new NotImplementedException();
    }

    public static Matrix<char> CreateCipherBoard(string keyword)
    {
        var distinct = keyword.ToCharArray().Distinct();
        var otherChars = _cipherAlphabet.Where(o => !distinct.Contains(o) && o != 'j');
        var combined = distinct.Concat(otherChars).ToArray();
        var size = 5;
        var matrix = new Matrix<char>(size, size);

        for (var i = 0; i < combined.Length; i++)
        {
            var x = i % 5;
            var y = i / 5;
            matrix.WriteValueAt(x, y, combined[i]);
        }

        return matrix;
    }
}
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aquaq.Puzzles.Aquaq31.RubiksCube;

public class CubeFace
{
    private const int Size = 3;
    private Matrix<char> _matrix;

    public CubeFace(char initial)
    {
        _matrix = new(Size, Size, initial);
    }

    public char TopLeft => _matrix.ReadValueAt(0, 0);
    public char Top => _matrix.ReadValueAt(1, 0);
    public char TopRight => _matrix.ReadValueAt(2, 0);
    public char Left => _matrix.ReadValueAt(1, 0);
    public char Center => _matrix.ReadValueAt(1, 1);
    public char Right => _matrix.ReadValueAt(1, 2);
    public char BottomLeft => _matrix.ReadValueAt(0, 2);
    public char Bottom => _matrix.ReadValueAt(1, 2);
    public char BottomRight => _matrix.ReadValueAt(2, 2);

    public char[] ReadAll() => _matrix.Values.ToArray();
    public char[] ReadLeftColumn() => ReadColumn(0);
    public char[] ReadRightColumn() => ReadColumn(2);
    private char[] ReadColumn(int x) => Enumerable.Range(0, Size).Select(o => _matrix.ReadValueAt(x, o)).ToArray();

    public char[] ReadTopRow() => ReadRow(0);
    public char[] ReadBottomRow() => ReadRow(2);
    private char[] ReadRow(int y) => Enumerable.Range(0, Size).Select(o => _matrix.ReadValueAt(o, y)).ToArray();

    public Matrix<char> Matrix => _matrix.Clone();

    public void WriteAll(IEnumerable<char> chars)
    {
        var charArray = chars.ToArray();
        var coordsArray = _matrix.Coords.ToArray();
        for (var i = 0; i < coordsArray.Length; i++)
        {
            _matrix.WriteValueAt(coordsArray[i], charArray[i]);
        }
    }

    public void WriteTopRow(IEnumerable<char> values) => WriteRow(0, values);
    public void WriteBottomRow(IEnumerable<char> values) => WriteRow(2, values);
    private void WriteRow(int y, IEnumerable<char> values)
    {
        var x = 0;
        foreach (var value in values)
        {
            _matrix.WriteValueAt(x, y, value);
            x++;
        }
    }

    public void WriteLeftColumn(IEnumerable<char> values) => WriteColumn(0, values);
    public void WriteRightColumn(IEnumerable<char> values) => WriteColumn(2, values);
    private void WriteColumn(int x, IEnumerable<char> values)
    {
        var y = 0;
        foreach (var value in values)
        {
            _matrix.WriteValueAt(x, y, value);
            y++;
        }
    }

    public void RotateRight() => _matrix = _matrix.RotateRight();
    public void RotateLeft() => _matrix = _matrix.RotateLeft();
    public string PrintFlat() => string.Join("", _matrix.Values);
    public string Print() => _matrix.Print();
    public int Product => _matrix.Values.Select(GetColorValue).Aggregate(1, (a, b) => a * b);

    private static int GetColorValue(char c) => c switch
    {
        CubeColors.Blue => 1,
        CubeColors.White => 2,
        CubeColors.Red => 3,
        CubeColors.Orange => 4,
        CubeColors.Yellow => 5,
        CubeColors.Green => 6,
        _ => throw new Exception("Unknown color")
    };
}
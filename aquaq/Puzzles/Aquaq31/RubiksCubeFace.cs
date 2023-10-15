using Common.CoordinateSystems.CoordinateSystem2D;

namespace Aquaq.Puzzles.Aquaq31;

public class RubiksCubeFace
{
    private const int Size = 3;
    private Matrix<char> _matrix;

    public RubiksCubeFace(char initial)
    {
        _matrix = new Matrix<char>(Size, Size, initial);
    }

    public char[] ReadColumn(int x)
    {
        return Enumerable.Range(0, Size).Select(o => _matrix.ReadValueAt(x, o)).ToArray();
    }

    public char[] ReadReverseColumn(int y)
    {
        return ReadColumn(y).Reverse().ToArray();
    }

    public void WriteRow(int y, IEnumerable<char> values)
    {
        var x = 0;
        foreach (var value in values)
        {
            _matrix.WriteValueAt(x, y, value);
            x++;
        }
    }

    public void WriteReverseRow(int y, IEnumerable<char> values)
    {
        WriteRow(y, values.Reverse());
    }

    public char[] ReadRow(int y)
    {
        return Enumerable.Range(0, Size).Select(o => _matrix.ReadValueAt(o, y)).ToArray();
    }

    public char[] ReadReverseRow(int x)
    {
        return ReadRow(x).Reverse().ToArray();
    }

    public void WriteColumn(int x, IEnumerable<char> values)
    {
        var y = 0;
        foreach (var value in values)
        {
            _matrix.WriteValueAt(x, y, value);
            y++;
        }
    }

    public void WriteReverseColumn(int x, IEnumerable<char> values)
    {
        WriteColumn(x, values.Reverse());
    }
    
    public void RotateRight()
    {
        _matrix = _matrix.RotateRight();
    }

    public void RotateLeft()
    {
        _matrix = _matrix.RotateLeft();
    }

    public string Print()
    {
        return string.Join("", _matrix.Values);
    }

    public int Product => _matrix.Values.Select(GetColorValue).Aggregate(1, (a, b) => a * b);

    private int GetColorValue(char c)
    {
        return c switch
        {
            'b' => 1,
            'w' => 2,
            'r' => 3,
            'o' => 4,
            'y' => 5,
            'g' => 6,
            _ => throw new Exception("Unknown color")
        };
    }
}
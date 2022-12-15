using System.Collections.Generic;
using System.Linq;

namespace Core.Common.CoordinateSystems.CoordinateSystem2D;

public class QuickDynamicMatrix<T> : Base2DMatrix<T>, IDynamicMatrix<T>
{
    private readonly IDictionary<MatrixAddress, T> _matrix;
    private int _minx;
    private int _maxx;
    private int _miny;
    private int _maxy;

    public override IEnumerable<T> Values => _matrix.Values;
    public override int Width => _maxx - _minx + 1;
    public override int Height => _maxy - _miny + 1;
    public override int XMin => _minx;
    public override int XMax => _maxx;
    public override int YMin => _miny;
    public override int YMax => _maxy;

    public QuickDynamicMatrix(int width = 1, int height = 1, T defaultValue = default)
        : base(defaultValue)
    {
        _minx = 0;
        _maxx = width - 1;
        _miny = 0;
        _maxy = height - 1;
        _matrix = new Dictionary<MatrixAddress, T>();
    }

    public QuickDynamicMatrix(IDictionary<MatrixAddress, T> values, T defaultValue = default)
        : base(defaultValue)
    {
        _matrix = values;
        _minx = 0;
        _maxx = _matrix.Keys.Select(o => o.X).Max();
        _miny = 0;
        _maxy = _matrix.Keys.Select(o => o.Y).Max();
    }

    public override T ReadValueAt(int x, int y)
    {
        return _matrix.TryGetValue(new MatrixAddress(x, y), out var v)
            ? v
            : DefaultValue;
    }

    public override void WriteValueAt(int x, int y, T value)
    {
        _matrix[new MatrixAddress(x, y)] = value;
    }
    
    protected override IMatrix<T> Create(int width, int height, T defaultValue = default)
    {
        return new QuickDynamicMatrix<T>(width, height, DefaultValue);
    }

    protected override void HandleExtend(MatrixAddress address)
    {
        ExtendMatrix(address);
    }

    private void ExtendMatrix(MatrixAddress address)
    {
        ExtendX(address);
        ExtendY(address);
    }

    private void ExtendX(MatrixAddress address)
    {
        if (address.X < XMin)
            ExtendLeft(address);
        ExtendRight(address);
    }

    private void ExtendLeft(MatrixAddress address)
    {
        AddCols(-address.X, MatrixAddMode.Prepend);
        StartAddress = new MatrixAddress(StartAddress.X - address.X, StartAddress.Y);
    }

    private void ExtendRight(MatrixAddress address)
    {
        var extendBy = address.X - (Width - 1);
        if (extendBy > 0)
            AddCols(extendBy, MatrixAddMode.Append);
    }

    private void ExtendY(MatrixAddress address)
    {
        if (address.Y < YMin)
            ExtendTop(address);
        ExtendBottom(address);
    }

    private void ExtendTop(MatrixAddress address)
    {
        AddRows(-address.Y, MatrixAddMode.Prepend);
        StartAddress = new MatrixAddress(StartAddress.X, StartAddress.Y - address.Y);
    }

    private void ExtendBottom(MatrixAddress address)
    {
        var extendBy = address.Y - (Height - 1);
        if (extendBy > 0)
            AddRows(extendBy, MatrixAddMode.Append);
    }

    private void AddRows(int numberOfRows, MatrixAddMode addMode)
    {
        if (addMode == MatrixAddMode.Prepend)
            _miny -= numberOfRows;
        else
            _maxy += numberOfRows;
    }

    private void AddCols(int numberOfCols, MatrixAddMode addMode)
    {
        if (addMode == MatrixAddMode.Prepend)
            _minx -= numberOfCols;
        else
            _maxx += numberOfCols;
    }

    public void ExtendAllDirections(int steps = 1)
    {
        ExtendUp(steps);
        ExtendRight(steps);
        ExtendDown(steps);
        ExtendLeft(steps);
    }

    public void ExtendUp(int steps = 1)
    {
        AddRows(steps, MatrixAddMode.Prepend);
    }

    public void ExtendRight(int steps = 1)
    {
        AddCols(steps, MatrixAddMode.Append);
    }

    public void ExtendDown(int steps = 1)
    {
        AddRows(steps, MatrixAddMode.Append);
    }

    public void ExtendLeft(int steps = 1)
    {
        AddCols(steps, MatrixAddMode.Prepend);
    }

    public override IMatrix<T> Copy()
    {
        var matrix = Create(Width, Height);
        for (var y = YMin; y <= YMax; y++)
        {
            for (var x = XMin; x <= XMax; x++)
            {
                matrix.WriteValueAt(x, y, ReadValueAt(x, y));
            }
        }

        matrix.MoveTo(Address);
        return matrix;
    }

    public override IMatrix<T> RotateLeft()
    {
        var newMatrix = Create(Height, Width, DefaultValue);
        var oy = YMin;
        for (var ox = XMax; ox >= XMin; ox--)
        {
            var nx = XMin;
            for (var ny = YMin; ny <= YMax; ny++)
            {
                newMatrix.WriteValueAt(nx, oy, ReadValueAt(ox, ny));
                nx++;
            }
            oy++;
        }
        return newMatrix;
    }

    public override IMatrix<T> RotateRight()
    {
        return RotateLeft().RotateLeft().RotateLeft();
    }

    public override IMatrix<T> Slice(MatrixAddress from = null, MatrixAddress to = null)
    {
        from ??= new MatrixAddress(XMin, YMin);
        to ??= new MatrixAddress(YMax, YMax);
        var dx = from.X;
        var dy = from.Y;
        var values = _matrix
            .Where(item => item.Key.X >= from.X && item.Key.Y >= from.Y && item.Key.X <= to.X && item.Key.Y <= to.Y)
            .ToDictionary(item => new MatrixAddress(item.Key.X - dx, item.Key.Y - dy), item => item.Value);
        var newMatrix = new QuickDynamicMatrix<T>(values, DefaultValue);
        return newMatrix;
    }

    public override IMatrix<T> Slice(MatrixAddress from, int width, int height)
    {
        var to = new MatrixAddress(from.X + width, from.Y + height);
        return Slice(from, to);
    }

    public override IMatrix<T> FlipVertical()
    {
        var width = Width;
        var height = Height;
        var newMatrix = Create(width, height, DefaultValue);
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var ny = height - y - 1;
                newMatrix.WriteValueAt(x, ny, ReadValueAt(x, y));
            }
        }
        return newMatrix;
    }

    public override IMatrix<T> FlipHorizontal()
    {
        var width = Width;
        var height = Height;
        var newMatrix = Create(width, height, DefaultValue);
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var nx = width - x - 1;
                newMatrix.WriteValueAt(nx, y, ReadValueAt(x, y));
            }
        }
        return newMatrix;
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Core.Common.CoordinateSystems.CoordinateSystem2D;

public class QuickDynamicMatrix<T> : Base2DMatrix<T>, IDynamicMatrix<T>
{
    private readonly IDictionary<MatrixAddress, T> _matrix;
    private int _width;
    private int _height;

    public override IEnumerable<T> Values => _matrix.Values;
    public override int Width => _width;
    public override int Height => _height;

    public QuickDynamicMatrix(int width = 1, int height = 1, T defaultValue = default)
        : base(defaultValue)
    {
        _width = 1;
        _height = 1;
        _matrix = new Dictionary<MatrixAddress, T>();
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
        if (address.X < 0)
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
        if (address.Y < 0)
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
        _height += numberOfRows;
    }

    private void AddCols(int numberOfCols, MatrixAddMode addMode)
    {
        _width += numberOfCols;
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
}
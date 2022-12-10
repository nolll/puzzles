using System.Collections.Generic;
using System.Linq;

namespace Core.Common.CoordinateSystems.CoordinateSystem2D;

public class DynamicMatrix<T> : Base2DMatrix<T>, IMatrix<T>
{
    private readonly IList<IList<T>> _matrix;

    public override IEnumerable<T> Values => _matrix.SelectMany(x => x).ToList();
    public override int Height => _matrix.Count;
    public override int Width => _matrix.Any() ? _matrix[0].Count : 0;

    public DynamicMatrix(int width = 1, int height = 1, T defaultValue = default)
        : base(defaultValue)
    {
        _matrix = BuildDynamicMatrix(width, height, defaultValue);
    }

    public override T ReadValueAt(int x, int y)
    {
        return _matrix[y][x];
    }

    public override void WriteValueAt(int x, int y, T value)
    {
        _matrix[y][x] = value;
    }

    private IList<IList<T>> BuildDynamicMatrix(int width, int height, T defaultValue)
    {
        var matrix = new List<IList<T>>();
        for (var y = 0; y < height; y++)
        {
            var row = new List<T>();
            for (var x = 0; x < width; x++)
            {
                row.Add(defaultValue);
            }
            matrix.Add(row);
        }
        return matrix;
    }

    protected override IMatrix<T> Create(int width, int height, T defaultValue)
    {
        return new DynamicMatrix<T>(width, height, DefaultValue);
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
        var width = Width;
        for (var y = 0; y < numberOfRows; y++)
        {
            var row = new List<T>();
            for (var x = 0; x < width; x++)
            {
                row.Add(DefaultValue);
            }

            if (addMode == MatrixAddMode.Prepend)
                _matrix.Insert(0, row);
            else
                _matrix.Add(row);
        }
    }

    private void AddCols(int numberOfRows, MatrixAddMode addMode)
    {
        var height = Height;
        for (var y = 0; y < height; y++)
        {
            var row = _matrix[y];
            for (var x = 0; x < numberOfRows; x++)
            {
                if (addMode == MatrixAddMode.Prepend)
                    row.Insert(0, DefaultValue);
                else
                    row.Add(DefaultValue);
            }
        }
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
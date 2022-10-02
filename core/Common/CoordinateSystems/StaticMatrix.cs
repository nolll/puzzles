using System.Collections.Generic;

namespace Core.Common.CoordinateSystems;

public class StaticMatrix<T> : BaseMatrix<T>, IMatrix<T>
{
    private readonly T[,] _matrix;

    public override int Width { get; }
    public override int Height { get; }

    public StaticMatrix(int width = 1, int height = 1, T defaultValue = default)
        : base(defaultValue)
    {
        _matrix = new T[width, height];
        _matrix = BuildStaticMatrix(width, height, defaultValue);
        Width = width;
        Height = height;
    }

    public override IEnumerable<T> Values
    {
        get
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    yield return _matrix[x, y];
                }
            }
        }
    }

    public override T ReadValueAt(int x, int y)
    {
        return _matrix[x, y];
    }

    public override void WriteValueAt(int x, int y, T value)
    {
        _matrix[x, y] = value;
    }

    private T[,] BuildStaticMatrix(int width, int height, T defaultValue)
    {
        var matrix = new T[Width, height];
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                matrix[x, y] = defaultValue;
            }
        }
        return matrix;
    }

    protected override IMatrix<T> Create(int width, int height, T defaultValue)
    {
        return new StaticMatrix<T>(width, height, _defaultValue);
    }
}
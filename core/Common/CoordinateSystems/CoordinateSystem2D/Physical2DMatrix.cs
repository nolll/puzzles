namespace Core.Common.CoordinateSystems.CoordinateSystem2D;

public abstract class Physical2DMatrix<T> : Base2DMatrix<T>
{
    protected Physical2DMatrix(T defaultValue)
        : base(defaultValue)
    {
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
        var xNew = 0;
        var yNew = 0;
        var width = to.X - from.X;
        var height = to.Y - from.Y;
        var newMatrix = Create(width, height, DefaultValue);
        for (var y = from.Y; y <= to.Y; y++)
        {
            for (var x = from.X; x <= to.X; x++)
            {
                newMatrix.MoveTo(xNew, yNew);
                newMatrix.WriteValue(ReadValueAt(x, y));

                xNew++;
            }

            xNew = 0;
            yNew++;
        }
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
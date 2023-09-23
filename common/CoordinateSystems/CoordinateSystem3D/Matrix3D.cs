using System.Text;

namespace Common.CoordinateSystems.CoordinateSystem3D;

public class Matrix3D<T> : BaseMatrix
{
    private readonly T _defaultValue;
    private readonly IList<IList<IList<T>>> _matrix;
    public Matrix3DAddress Address { get; private set; }
    public Matrix3DAddress StartAddress { get; set; }

    public IList<T> Values => _matrix.SelectMany(x => x).SelectMany(x => x).ToList();
    public int Depth => _matrix.Count;
    public int Height => _matrix.Any() ? _matrix[0].Count : 0;
    public int Width => _matrix.Any() && _matrix[0].Any() ? _matrix[0][0].Count : 0;
    public bool IsAtTop => Address.Y == 0;
    public bool IsAtRightEdge => Address.X == Width - 1;
    public bool IsAtBottom => Address.Y == Height - 1;
    public bool IsAtLeftEdge => Address.X == 0;
    public Matrix3DAddress Center => new(Width / 2, Height / 2, Depth / 2);

    public Matrix3D(int width = 1, int height = 1, int depth = 1, T defaultValue = default)
    {
        _defaultValue = defaultValue;
        _matrix = BuildMatrix(width, height, depth, defaultValue);
        Address = new Matrix3DAddress(0, 0, 0);
        StartAddress = new Matrix3DAddress(0, 0, 0);
    }

    public bool TryMoveTo(Matrix3DAddress address)
    {
        return MoveTo(address, false);
    }

    public bool MoveTo(Matrix3DAddress address)
    {
        return MoveTo(address, true);
    }

    private bool MoveTo(Matrix3DAddress address, bool extend)
    {
        if (IsOutOfRange(address))
        {
            if (extend)
                ExtendMatrix(address);
            else
                return false;
        }

        var x = address.X > 0 ? address.X : 0;
        var y = address.Y > 0 ? address.Y : 0;
        var z = address.Z > 0 ? address.Z : 0;
        Address = new Matrix3DAddress(x, y, z);
        return true;
    }

    public bool TryMoveTo(int x, int y, int z)
    {
        return MoveTo(new Matrix3DAddress(x, y, z), false);
    }

    public bool MoveTo(int x, int y, int z)
    {
        return MoveTo(new Matrix3DAddress(x, y, z), true);
    }

    public bool TryMoveUp(int steps = 1)
    {
        return MoveUp(steps, false);
    }

    public bool MoveUp(int steps = 1)
    {
        return MoveUp(steps, true);
    }

    private bool MoveUp(int steps, bool extend)
    {
        return MoveTo(new Matrix3DAddress(Address.X, Address.Y - steps, Address.Z), extend);
    }

    public bool TryMoveRight(int steps = 1)
    {
        return MoveRight(steps, false);
    }

    public bool MoveRight(int steps = 1)
    {
        return MoveRight(steps, true);
    }

    private bool MoveRight(int steps, bool extend)
    {
        return MoveTo(new Matrix3DAddress(Address.X + steps, Address.Y, Address.Z), extend);
    }

    public bool TryMoveDown(int steps = 1)
    {
        return MoveDown(steps, false);
    }

    public bool MoveDown(int steps = 1)
    {
        return MoveDown(steps, true);
    }

    private bool MoveDown(int steps, bool extend)
    {
        return MoveTo(new Matrix3DAddress(Address.X, Address.Y + steps, Address.Z), extend);
    }

    public bool TryMoveLeft(int steps = 1)
    {
        return MoveLeft(steps, false);
    }

    public bool MoveLeft(int steps = 1)
    {
        return MoveLeft(steps, true);
    }

    private bool MoveLeft(int steps, bool extend)
    {
        return MoveTo(new Matrix3DAddress(Address.X - steps, Address.Y, Address.Z), extend);
    }
        
    public T ReadValue()
    {
        return ReadValueAt(Address.X, Address.Y, Address.Z);
    }

    public T ReadValueAt(Matrix3DAddress address)
    {
        return ReadValueAt(address.X, address.Y, address.Z);
    }

    public T ReadValueAt(int x, int y, int z)
    {
        return _matrix[z][y][x];
    }

    public void WriteValue(T value)
    {
        _matrix[Address.Z][Address.Y][Address.X] = value;
    }

    public bool IsOutOfRange(Matrix3DAddress address)
    {
        return address.Z >= Depth ||
               address.Z < 0 || 
               address.Y >= Height ||
               address.Y < 0 ||
               address.X >= Width ||
               address.X < 0;
    }

    public IList<T> PerpendicularAdjacentValues => PerpendicularAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<Matrix3DAddress> PerpendicularAdjacentCoords => PossiblePerpendicularAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();

    private IList<Matrix3DAddress> PossiblePerpendicularAdjacentCoords =>
        new List<Matrix3DAddress>
        {
            new Matrix3DAddress(Address.X + 1, Address.Y, Address.Z),
            new Matrix3DAddress(Address.X - 1, Address.Y, Address.Z),
            new Matrix3DAddress(Address.X, Address.Y + 1, Address.Z),
            new Matrix3DAddress(Address.X, Address.Y - 1, Address.Z),
            new Matrix3DAddress(Address.X, Address.Y, Address.Z + 1),
            new Matrix3DAddress(Address.X, Address.Y, Address.Z - 1)
        };

    public IList<T> AllAdjacentValues => AllAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<Matrix3DAddress> AllAdjacentCoords => AllPossibleAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();

    private IEnumerable<Matrix3DAddress> AllPossibleAdjacentCoords
    {
        get
        {
            foreach (var dz in AdjacentDeltas)
            {
                foreach (var dy in AdjacentDeltas)
                {
                    foreach (var dx in AdjacentDeltas)
                    {
                        var coord = new Matrix3DAddress(Address.X + dx, Address.Y - dy, Address.Z - dz);
                        if (!coord.Equals(Address))
                            yield return coord;
                    }
                }
            }
        }
    }

    public Matrix3D<T> Copy()
    {
        var matrix = new Matrix3D<T>();
        for (var z = 0; z < Depth; z++)
        {
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    matrix.MoveTo(x, y, z);
                    matrix.WriteValue(ReadValueAt(x, y, z));
                }
            }
        }

        matrix.MoveTo(Address);
        return matrix;
    }

    private IList<IList<IList<T>>> BuildMatrix(int width, int height, int depth, T defaultValue)
    {
        var matrix = new List<IList<IList<T>>>();
        for (var z = 0; z < depth; z++)
        {
            var level = new List<IList<T>>();
            for (var y = 0; y < height; y++)
            {
                var row = new List<T>();
                for (var x = 0; x < width; x++)
                {
                    row.Add(defaultValue);
                }

                level.Add(row);
            }

            matrix.Add(level);
        }

        return matrix;
    }

    private void ExtendMatrix(Matrix3DAddress address)
    {
        ExtendX(address);
        ExtendY(address);
        ExtendZ(address);
    }

    private void ExtendX(Matrix3DAddress address)
    {
        if (address.X < 0)
            ExtendLeft(address);
        ExtendRight(address);
    }

    private void ExtendLeft(Matrix3DAddress address)
    {
        AddCols(-address.X, MatrixAddMode.Prepend);
        StartAddress = new Matrix3DAddress(StartAddress.X - address.X, StartAddress.Y, StartAddress.Z);
    }

    private void ExtendRight(Matrix3DAddress address)
    {
        var extendBy = address.X - (Width - 1);
        if (extendBy > 0)
            AddCols(extendBy, MatrixAddMode.Append);
    }

    private void ExtendY(Matrix3DAddress address)
    {
        if (address.Y < 0)
            ExtendTop(address);
        ExtendBottom(address);
    }

    private void ExtendTop(Matrix3DAddress address)
    {
        AddRows(-address.Y, MatrixAddMode.Prepend);
        StartAddress = new Matrix3DAddress(StartAddress.X, StartAddress.Y - address.Y, StartAddress.Z);
    }

    private void ExtendBottom(Matrix3DAddress address)
    {
        var extendBy = address.Y - (Height - 1);
        if (extendBy > 0)
            AddRows(extendBy, MatrixAddMode.Append);
    }

    private void ExtendZ(Matrix3DAddress address)
    {
        if (address.Z < 0)
            ExtendClose(address);
        ExtendFar(address);
    }

    private void ExtendClose(Matrix3DAddress address)
    {
        AddLevels(-address.Z, MatrixAddMode.Prepend);
        StartAddress = new Matrix3DAddress(StartAddress.X, StartAddress.Y, StartAddress.Z - address.Z);
    }

    private void ExtendFar(Matrix3DAddress address)
    {
        var extendBy = address.Z - (Depth - 1);
        if (extendBy > 0)
            AddLevels(extendBy, MatrixAddMode.Append);
    }

    public void ExtendAllDirections(int steps = 1)
    {
        AddCols(steps, MatrixAddMode.Prepend);
        AddCols(steps, MatrixAddMode.Append);
        AddRows(steps, MatrixAddMode.Prepend);
        AddRows(steps, MatrixAddMode.Append);
        AddLevels(steps, MatrixAddMode.Prepend);
        AddLevels(steps, MatrixAddMode.Append);
    }

    private void AddRows(int numberOfRows, MatrixAddMode addMode)
    {
        var width = Width;
        var depth = Depth;
        for (var z = 0; z < depth; z++)
        {
            var level = _matrix[z];
            for (var y = 0; y < numberOfRows; y++)
            {
                var row = new List<T>();
                for (var x = 0; x < width; x++)
                {
                    row.Add(_defaultValue);
                }

                if (addMode == MatrixAddMode.Prepend)
                    level.Insert(0, row);
                else
                    level.Add(row);
            }
        }
    }

    private void AddCols(int numberOfCols, MatrixAddMode addMode)
    {
        var height = Height;
        var depth = Depth;
        for (var z = 0; z < depth; z++)
        {
            var level = _matrix[z];
            for (var y = 0; y < height; y++)
            {
                var row = level[y];
                for (var x = 0; x < numberOfCols; x++)
                {
                    if(addMode == MatrixAddMode.Prepend)
                        row.Insert(0, _defaultValue);
                    else 
                        row.Add(_defaultValue);
                }
            }
        }
    }

    private void AddLevels(int numberOfLevels, MatrixAddMode addMode)
    {
        var height = Height;
        var width = Width;
        for (var z = 0; z < numberOfLevels; z++)
        {
            var level = new List<IList<T>>();
            for (var y = 0; y < height; y++)
            {
                var row = new List<T>();
                for (var x = 0; x < width; x++)
                {
                    row.Add(_defaultValue);
                }
                level.Add(row);
            }

            if(addMode == MatrixAddMode.Prepend)
                _matrix.Insert(0, level);
            else
                _matrix.Add(level);
        }
    }

    public string PrintLevel(int level)
    {
        var sb = new StringBuilder();
        foreach (var row in _matrix[level])
        {
            foreach (var o in row)
            {
                sb.Append(o);
            }

            sb.AppendLine();
        }

        return sb.ToString().Trim();
    }
}
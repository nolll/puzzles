using System.Text;

namespace Pzl.Tools.CoordinateSystems.CoordinateSystem3D;

public class Matrix3D<T> where T : struct
{
    private readonly T _defaultValue;
    private readonly IDictionary<Matrix3DAddress, T> _matrix = new Dictionary<Matrix3DAddress, T>();
    public Matrix3DAddress Address { get; private set; }
    public Matrix3DAddress StartAddress { get; set; }
    
    public int Width => XMax - XMin + 1;
    public int Height => YMax - YMin + 1;
    public int Depth => ZMax - ZMin + 1;
    public int XMin { get; private set; }
    public int XMax { get; private set; }
    public int YMin { get; private set; }
    public int YMax { get; private set; }
    public int ZMin { get; private set; }
    public int ZMax { get; private set; }
    public bool IsAtTop => Address.Y == 0;
    public bool IsAtRightEdge => Address.X == Width - 1;
    public bool IsAtBottom => Address.Y == Height - 1;
    public bool IsAtLeftEdge => Address.X == 0;
    
    public Matrix3DAddress Center
    {
        get
        {
            var xDiff = Math.Abs(XMax - XMin);
            var yDiff = Math.Abs(YMax - YMin);
            var zDiff = Math.Abs(ZMax - ZMin);
            return new(XMax - xDiff / 2, YMax - yDiff / 2, ZMax - zDiff / 2);
        }
    }

    public Matrix3D(int width = 1, int height = 1, int depth = 1, T defaultValue = default)
    {
        _defaultValue = defaultValue;
        _matrix = BuildMatrix(width, height, depth, defaultValue);
        XMax = width - 1;
        YMax = height - 1;
        ZMax = depth - 1;
        Address = new Matrix3DAddress(0, 0, 0);
        StartAddress = new Matrix3DAddress(0, 0, 0);
    }
    
    public IEnumerable<T> Values =>
        Coords.Select(coord => _matrix.TryGetValue(coord, out var v) 
            ? v 
            : _defaultValue);

    public IEnumerable<Matrix3DAddress> Coords
    {
        get
        {
            for (int z = ZMin; z <= ZMax; z++)
            {
                for (var y = YMin; y <= YMax; y++)
                {
                    for (var x = XMin; x <= XMax; x++)
                    {
                        yield return new Matrix3DAddress(x, y, z);
                    }
                }   
            }
        }
    }

    public bool TryMoveTo(Matrix3DAddress address) => MoveTo(address, false);
    public bool MoveTo(Matrix3DAddress address) => MoveTo(address, true);

    private bool MoveTo(Matrix3DAddress address, bool extend)
    {
        if (IsOutOfRange(address))
        {
            if (extend)
                ExtendMatrix(address);
            else
                return false;
        }

        var x = address.X > XMin ? address.X : XMin;
        var y = address.Y > YMin ? address.Y : YMin;
        var z = address.Z > ZMin ? address.Z : ZMin;
        Address = new Matrix3DAddress(x, y, z);
        return true;
    }

    public bool TryMoveTo(int x, int y, int z) => MoveTo(new Matrix3DAddress(x, y, z), false);
    public bool MoveTo(int x, int y, int z) => MoveTo(new Matrix3DAddress(x, y, z), true);
    public bool TryMoveUp(int steps = 1) => MoveUp(steps, false);
    public bool MoveUp(int steps = 1) => MoveUp(steps, true);
    private bool MoveUp(int steps, bool extend) => MoveTo(new Matrix3DAddress(Address.X, Address.Y - steps, Address.Z), extend);
    public bool TryMoveRight(int steps = 1) => MoveRight(steps, false);
    public bool MoveRight(int steps = 1) => MoveRight(steps, true);
    private bool MoveRight(int steps, bool extend) => MoveTo(new Matrix3DAddress(Address.X + steps, Address.Y, Address.Z), extend);
    public bool TryMoveDown(int steps = 1) => MoveDown(steps, false);
    public bool MoveDown(int steps = 1) => MoveDown(steps, true);
    private bool MoveDown(int steps, bool extend) => MoveTo(new Matrix3DAddress(Address.X, Address.Y + steps, Address.Z), extend);
    public bool TryMoveLeft(int steps = 1) => MoveLeft(steps, false);
    public bool MoveLeft(int steps = 1) => MoveLeft(steps, true);
    private bool MoveLeft(int steps, bool extend) => MoveTo(new Matrix3DAddress(Address.X - steps, Address.Y, Address.Z), extend);
    public T ReadValue() => ReadValueAt(Address.X, Address.Y, Address.Z);

    public T ReadValueAt(Matrix3DAddress coord) => _matrix.TryGetValue(coord, out var v)
        ? v
        : _defaultValue;

    public T ReadValueAt(int x, int y, int z) => ReadValueAt(new Matrix3DAddress(x, y, z));
    public void WriteValue(T value) => WriteValueAt(Address, value);
    
    public void WriteValueAt(Matrix3DAddress coord, T value)
    {
        if (coord.X < XMin)
            XMin = coord.X;
        else if (coord.X > XMax)
            XMax = coord.X;

        if (coord.Y < YMin)
            YMin = coord.Y;
        else if (coord.Y > YMax)
            YMax = coord.Y;
        
        if (coord.Z < ZMin)
            ZMin = coord.Z;
        else if (coord.Z > ZMax)
            ZMax = coord.Z;
        
        _matrix[coord] = value;
    }

    public bool IsOutOfRange(Matrix3DAddress address) =>
        address.Z > ZMax ||
        address.Z < ZMin || 
        address.Y > YMax ||
        address.Y < YMin ||
        address.X > XMax ||
        address.X < XMin;

    public IList<T> OrthogonalAdjacentValues => OrthogonalAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<Matrix3DAddress> OrthogonalAdjacentCoords => PossibleOrthogonalAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();

    private IList<Matrix3DAddress> PossibleOrthogonalAdjacentCoords =>
    [
        new(Address.X + 1, Address.Y, Address.Z),
        new(Address.X - 1, Address.Y, Address.Z),
        new(Address.X, Address.Y + 1, Address.Z),
        new(Address.X, Address.Y - 1, Address.Z),
        new(Address.X, Address.Y, Address.Z + 1),
        new(Address.X, Address.Y, Address.Z - 1)
    ];

    public IList<T> AllAdjacentValues => AllAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<Matrix3DAddress> AllAdjacentCoords => AllPossibleAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();

    private IEnumerable<Matrix3DAddress> AllPossibleAdjacentCoords
    {
        get
        {
            foreach (var dz in MatrixConstants.AdjacentDeltas)
            {
                foreach (var dy in MatrixConstants.AdjacentDeltas)
                {
                    foreach (var dx in MatrixConstants.AdjacentDeltas)
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

    private Dictionary<Matrix3DAddress, T> BuildMatrix(int width, int height, int depth, T defaultValue)
    {
        var matrix = new Dictionary<Matrix3DAddress, T>();
        for (var z = 0; z < depth; z++)
        {
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    matrix.Add(new Matrix3DAddress(x, y, z), defaultValue);
                }
            }
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
        if (addMode == MatrixAddMode.Prepend)
            YMin -= numberOfRows;
        else
            YMax += numberOfRows;
    }

    private void AddCols(int numberOfCols, MatrixAddMode addMode)
    {
        if (addMode == MatrixAddMode.Prepend)
            XMin -= numberOfCols;
        else
            XMax += numberOfCols;
    }

    private void AddLevels(int numberOfLevels, MatrixAddMode addMode)
    {
        if (addMode == MatrixAddMode.Prepend)
            ZMin -= numberOfLevels;
        else
            ZMax += numberOfLevels;
    }
    
    public string Print(int z)
    {
        var sb = new StringBuilder();

        for (var y = YMin; y <= YMax; y++)
        {
            for (var x = XMin; x <= XMax; x++)
            { 
                sb.Append(ReadValueAt(x, y, z));
            }

            if(y < YMax)
                sb.AppendLine();
        }

        return sb.ToString();
    }

    public void Clear() => _matrix.Clear();
}
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Common.CoordinateSystems;

public class Matrix4D<T> : BaseMatrix
{
    private readonly T _defaultValue;
    private readonly IList<IList<IList<IList<T>>>> _matrix;
    public Matrix4DAddress Address { get; private set; }
    public Matrix4DAddress StartAddress { get; set; }

    public IList<T> Values => _matrix.SelectMany(x => x).SelectMany(x => x).SelectMany(x => x).ToList();
    public int Duration => _matrix.Count;
    public int Depth => _matrix.Any() ? _matrix[0].Count : 0;
    public int Height => _matrix.Any() && _matrix[0].Any() ? _matrix[0][0].Count : 0;
    public int Width => _matrix.Any() && _matrix[0].Any() && _matrix[0][0].Any() ? _matrix[0][0][0].Count : 0;
    public bool IsAtTop => Address.Y == 0;
    public bool IsAtRightEdge => Address.X == Width - 1;
    public bool IsAtBottom => Address.Y == Height - 1;
    public bool IsAtLeftEdge => Address.X == 0;
    public Matrix4DAddress Center => new Matrix4DAddress(Width / 2, Height / 2, Depth / 2, Duration / 2);

    public Matrix4D(int width = 1, int height = 1, int depth = 1, int duration = 1, T defaultValue = default)
    {
        _defaultValue = defaultValue;
        _matrix = BuildMatrix(width, height, depth, duration, defaultValue);
        Address = new Matrix4DAddress(0, 0, 0, 0);
        StartAddress = new Matrix4DAddress(0, 0, 0, 0);
    }

    public bool TryMoveTo(Matrix4DAddress address)
    {
        return MoveTo(address, false);
    }

    public bool MoveTo(Matrix4DAddress address)
    {
        return MoveTo(address, true);
    }

    private bool MoveTo(Matrix4DAddress address, bool extend)
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
        var w = address.W > 0 ? address.W : 0;
        Address = new Matrix4DAddress(x, y, z, w);
        return true;
    }

    public bool TryMoveTo(int x, int y, int z, int w)
    {
        return MoveTo(new Matrix4DAddress(x, y, z, w), false);
    }

    public bool MoveTo(int x, int y, int z, int w)
    {
        return MoveTo(new Matrix4DAddress(x, y, z, w), true);
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
        return MoveTo(new Matrix4DAddress(Address.X, Address.Y - steps, Address.Z, Address.W), extend);
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
        return MoveTo(new Matrix4DAddress(Address.X + steps, Address.Y, Address.Z, Address.W), extend);
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
        return MoveTo(new Matrix4DAddress(Address.X, Address.Y + steps, Address.Z, Address.W), extend);
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
        return MoveTo(new Matrix4DAddress(Address.X - steps, Address.Y, Address.Z, Address.W), extend);
    }

    public T ReadValue()
    {
        return ReadValueAt(Address.X, Address.Y, Address.Z, Address.W);
    }

    public T ReadValueAt(Matrix4DAddress address)
    {
        return ReadValueAt(address.X, address.Y, address.Z, address.W);
    }

    public T ReadValueAt(int x, int y, int z, int w)
    {
        return _matrix[w][z][y][x];
    }

    public void WriteValue(T value)
    {
        _matrix[Address.W][Address.Z][Address.Y][Address.X] = value;
    }

    public bool IsOutOfRange(Matrix4DAddress address)
    {
        return address.W >= Duration ||
               address.W < 0 ||
               address.Z >= Depth ||
               address.Z < 0 ||
               address.Y >= Height ||
               address.Y < 0 ||
               address.X >= Width ||
               address.X < 0;
    }

    public IList<T> PerpendicularAdjacentValues => PerpendicularAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<Matrix4DAddress> PerpendicularAdjacentCoords => PossiblePerpendicularAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();
        
    private IList<Matrix4DAddress> PossiblePerpendicularAdjacentCoords =>
        new List<Matrix4DAddress>
        {
            new Matrix4DAddress(Address.X + 1, Address.Y, Address.Z, Address.W),
            new Matrix4DAddress(Address.X - 1, Address.Y, Address.Z, Address.W),
            new Matrix4DAddress(Address.X, Address.Y + 1, Address.Z, Address.W),
            new Matrix4DAddress(Address.X, Address.Y - 1, Address.Z, Address.W),
            new Matrix4DAddress(Address.X, Address.Y, Address.Z + 1, Address.W),
            new Matrix4DAddress(Address.X, Address.Y, Address.Z - 1, Address.W),
            new Matrix4DAddress(Address.X, Address.Y, Address.Z, Address.W + 1),
            new Matrix4DAddress(Address.X, Address.Y, Address.Z, Address.W - 1)
        };

    public IList<T> AllAdjacentValues => AllAdjacentCoords.Select(ReadValueAt).ToList();
    public IList<Matrix4DAddress> AllAdjacentCoords => AllPossibleAdjacentCoords.Where(o => !IsOutOfRange(o)).ToList();

    private IEnumerable<Matrix4DAddress> AllPossibleAdjacentCoords
    {
        get
        {
            foreach (var dw in AdjacentDeltas)
            {
                foreach (var dz in AdjacentDeltas)
                {
                    foreach (var dy in AdjacentDeltas)
                    {
                        foreach (var dx in AdjacentDeltas)
                        {
                            var coord = new Matrix4DAddress(Address.X + dx, Address.Y + dy, Address.Z + dz, Address.W + dw);
                            if(!coord.Equals(Address))
                                yield return coord;
                        }
                    }
                }
            }
        }
    }

    public Matrix4D<T> Copy()
    {
        var matrix = new Matrix4D<T>();
        for (var w = 0; w < Duration; w++)
        {
            for (var z = 0; z < Depth; z++)
            {
                for (var y = 0; y < Height; y++)
                {
                    for (var x = 0; x < Width; x++)
                    {
                        matrix.MoveTo(x, y, z, w);
                        matrix.WriteValue(ReadValueAt(x, y, z, w));
                    }
                }
            }
        }

        matrix.MoveTo(Address);
        return matrix;
    }

    private IList<IList<IList<IList<T>>>> BuildMatrix(int width, int height, int depth, int duration, T defaultValue)
    {
        var matrix = new List<IList<IList<IList<T>>>>();
        for (var w = 0; w < duration; w++)
        {
            var time = new List<IList<IList<T>>>();
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

                time.Add(level);
            }

            matrix.Add(time);
        }

        return matrix;
    }

    private void ExtendMatrix(Matrix4DAddress address)
    {
        ExtendX(address);
        ExtendY(address);
        ExtendZ(address);
        ExtendW(address);
    }

    private void ExtendX(Matrix4DAddress address)
    {
        if (address.X < 0)
            ExtendLeft(address);
        ExtendRight(address);
    }

    private void ExtendLeft(Matrix4DAddress address)
    {
        AddCols(-address.X, MatrixAddMode.Prepend);
        StartAddress = new Matrix4DAddress(StartAddress.X - address.X, StartAddress.Y, StartAddress.Z, StartAddress.W);
    }

    private void ExtendRight(Matrix4DAddress address)
    {
        var extendBy = address.X - (Width - 1);
        if (extendBy > 0)
            AddCols(extendBy, MatrixAddMode.Append);
    }

    private void ExtendY(Matrix4DAddress address)
    {
        if (address.Y < 0)
            ExtendTop(address);
        ExtendBottom(address);
    }

    private void ExtendTop(Matrix4DAddress address)
    {
        AddRows(-address.Y, MatrixAddMode.Prepend);
        StartAddress = new Matrix4DAddress(StartAddress.X, StartAddress.Y - address.Y, StartAddress.Z, StartAddress.W);
    }

    private void ExtendBottom(Matrix4DAddress address)
    {
        var extendBy = address.Y - (Height - 1);
        if (extendBy > 0)
            AddRows(extendBy, MatrixAddMode.Append);
    }

    private void ExtendZ(Matrix4DAddress address)
    {
        if (address.Z < 0)
            ExtendClose(address);
        ExtendFar(address);
    }

    private void ExtendClose(Matrix4DAddress address)
    {
        AddLevels(-address.Z, MatrixAddMode.Prepend);
        StartAddress = new Matrix4DAddress(StartAddress.X, StartAddress.Y, StartAddress.Z - address.Z, StartAddress.W);
    }

    private void ExtendFar(Matrix4DAddress address)
    {
        var extendBy = address.Z - (Depth - 1);
        if (extendBy > 0)
            AddLevels(extendBy, MatrixAddMode.Append);
    }

    private void ExtendW(Matrix4DAddress address)
    {
        if (address.W < 0)
            ExtendNow(address);
        ExtendThen(address);
    }

    private void ExtendNow(Matrix4DAddress address)
    {
        AddTime(-address.W, MatrixAddMode.Prepend);
        StartAddress = new Matrix4DAddress(StartAddress.X, StartAddress.Y, StartAddress.Z, StartAddress.W - address.W);
    }

    private void ExtendThen(Matrix4DAddress address)
    {
        var extendBy = address.W - (Duration - 1);
        if (extendBy > 0)
            AddTime(extendBy, MatrixAddMode.Append);
    }

    public void ExtendAllDirections(int steps = 1)
    {
        AddCols(steps, MatrixAddMode.Prepend);
        AddCols(steps, MatrixAddMode.Append);
        AddRows(steps, MatrixAddMode.Prepend);
        AddRows(steps, MatrixAddMode.Append);
        AddLevels(steps, MatrixAddMode.Prepend);
        AddLevels(steps, MatrixAddMode.Append);
        AddTime(steps, MatrixAddMode.Prepend);
        AddTime(steps, MatrixAddMode.Append);
    }

    private void AddRows(int count, MatrixAddMode addMode)
    {
        var width = Width;
        var depth = Depth;
        var duration = Duration;
        for (var w = 0; w < duration; w++)
        {
            var time = _matrix[w];
            for (var z = 0; z < depth; z++)
            {
                var level = time[z];
                for (var y = 0; y < count; y++)
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
    }

    private void AddCols(int count, MatrixAddMode addMode)
    {
        var height = Height;
        var depth = Depth;
        var duration = Duration;
        for (var w = 0; w < duration; w++)
        {
            var time = _matrix[w];
            for (var z = 0; z < depth; z++)
            {
                var level = time[z];
                for (var y = 0; y < height; y++)
                {
                    var row = level[y];
                    for (var x = 0; x < count; x++)
                    {
                        if (addMode == MatrixAddMode.Prepend)
                            row.Insert(0, _defaultValue);
                        else
                            row.Add(_defaultValue);
                    }
                }
            }
        }
    }

    private void AddLevels(int count, MatrixAddMode addMode)
    {
        var height = Height;
        var width = Width;
        var duration = Duration;
        for (var w = 0; w < duration; w++)
        {
            var time = _matrix[w];
            for (var z = 0; z < count; z++)
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

                if (addMode == MatrixAddMode.Prepend)
                    time.Insert(0, level);
                else
                    time.Add(level);
                    
            }
        }
    }

    private void AddTime(int count, MatrixAddMode addMode)
    {
        var height = Height;
        var width = Width;
        var depth = Depth;
        for (var w = 0; w < count; w++)
        {
            var time = new List<IList<IList<T>>>();
            for (var z = 0; z < depth; z++)
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
                time.Add(level);
            }

            if(addMode == MatrixAddMode.Prepend)
                _matrix.Insert(0, time);
            else
                _matrix.Add(time);
        }
    }

    public string PrintLevel(int time, int level)
    {
        var sb = new StringBuilder();
        foreach (var row in _matrix[time][level])
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
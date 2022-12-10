using System.Collections.Generic;

namespace Core.Common.CoordinateSystems.CoordinateSystem2D
{
    public interface IMatrix<T>
    {
        MatrixAddress Address { get; }
        IList<MatrixAddress> AllAdjacentCoords { get; }
        IList<T> AllAdjacentValues { get; }
        MatrixAddress Center { get; }
        IEnumerable<MatrixAddress> Coords { get; }
        MatrixDirection Direction { get; }
        int Height { get; }
        bool IsAtBottom { get; }
        bool IsAtLeftEdge { get; }
        bool IsAtRightEdge { get; }
        bool IsAtTop { get; }
        IList<MatrixAddress> PerpendicularAdjacentCoords { get; }
        IList<MatrixAddress> PerpendicularAdjacentCoordsTo(MatrixAddress address); 
        IList<T> PerpendicularAdjacentValues { get; }
        IList<T> PerpendicularAdjacentValuesTo(MatrixAddress address);
        MatrixAddress StartAddress { get; }
        IEnumerable<T> Values { get; }
        int Width { get; }

        IMatrix<T> Copy();
        IList<MatrixAddress> FindAddresses(T value);
        IMatrix<T> FlipHorizontal();
        IMatrix<T> FlipVertical();
        bool IsOutOfRange(MatrixAddress address);
        bool MoveBackward();
        bool MoveDown(int steps = 1);
        bool MoveForward();
        bool MoveLeft(int steps = 1);
        bool MoveRight(int steps = 1);
        bool MoveTo(int x, int y);
        bool MoveTo(MatrixAddress address);
        bool MoveUp(int steps = 1);
        string Print(bool markCurrentAddress = false, bool markStartAddress = false, T currentAddressMarker = default, T startAddressMarker = default, bool spacing = false);
        T ReadValue();
        T ReadValueAt(int x, int y);
        T ReadValueAt(MatrixAddress address);
        IMatrix<T> RotateLeft();
        IMatrix<T> RotateRight();
        IMatrix<T> Slice(MatrixAddress from = null, MatrixAddress to = null);
        IMatrix<T> Slice(MatrixAddress from, int width, int height);
        bool TryMoveBackward();
        bool TryMoveDown(int steps = 1);
        bool TryMoveForward();
        bool TryMoveLeft(int steps = 1);
        bool TryMoveRight(int steps = 1);
        bool TryMoveTo(int x, int y);
        bool TryMoveTo(MatrixAddress address);
        bool TryMoveUp(int steps = 1);
        MatrixDirection TurnLeft();
        MatrixDirection TurnRight();
        MatrixDirection TurnTo(MatrixDirection direction);
        void WriteValue(T value);
        void WriteValueAt(int x, int y, T value);
        void WriteValueAt(MatrixAddress address, T value);
    }
}
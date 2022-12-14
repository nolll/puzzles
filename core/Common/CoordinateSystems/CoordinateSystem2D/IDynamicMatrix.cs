namespace Core.Common.CoordinateSystems.CoordinateSystem2D;

public interface IDynamicMatrix<T> : IMatrix<T>
{
    void ExtendAllDirections(int steps = 1);
    void ExtendUp(int steps = 1);
    void ExtendRight(int steps = 1);
    void ExtendDown(int steps = 1);
    void ExtendLeft(int steps = 1);
}
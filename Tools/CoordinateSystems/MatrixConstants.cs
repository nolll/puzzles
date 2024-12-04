namespace Pzl.Tools.CoordinateSystems;

public static class MatrixConstants
{
    public static readonly int[] AdjacentDeltas = [-1, 0, 1];

    public static (int x, int y)[] OrthogonalDirections =>
    [
        (0, -1),
        (1, 0),
        (0, 1),
        (-1, 0)
    ];

    public static (int x, int y)[] AllDirections =>
    [
        (0, -1),
        (1, -1),
        (1, 0),
        (1, 1),
        (0, 1),
        (-1, 1),
        (-1, 0),
        (-1, -1)
    ];
}

namespace Pzl.Tools.Grids;

public static class GridConstants
{
    public static readonly int[] AdjacentDeltas = [-1, 0, 1];

    public static readonly (int x, int y)[] OrthogonalDirections =
    [
        (0, -1),
        (1, 0),
        (0, 1),
        (-1, 0)
    ];
    
    public static readonly (int x, int y)[] DiagonalDirections =
    [
        (1, -1),
        (1, 1),
        (-1, 1),
        (-1, -1)
    ];

    public static readonly (int x, int y)[] AllDirections =
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

using System;
using System.Collections.Generic;
using System.Linq;
using Common.CoordinateSystems.CoordinateSystem2D;

namespace Aoc.Puzzles.Aoc2020.Aoc202020;

public class SeaMonsterCounter
{
    private const string SeaMonsterPattern = """
..................#.
#....##....##....###
.#..#..#..#..#..#...
""";

    private readonly List<Func<Matrix<char>, Matrix<char>>> _searchFlips = new()
    {
        matrix => matrix.FlipVertical(),
        matrix => matrix.FlipHorizontal(),
        matrix => matrix.FlipVertical(),
        matrix => matrix.FlipHorizontal()
    };

    private readonly Matrix<char> _seaMonsterMatrix;
    private readonly List<MatrixAddress> _seaMonsterHashAddresses;

    public SeaMonsterCounter()
    {
        _seaMonsterMatrix = MatrixBuilder.BuildCharMatrix(SeaMonsterPattern);
        _seaMonsterHashAddresses = _seaMonsterMatrix.Coords.Where(o => _seaMonsterMatrix.ReadValueAt(o) == '#').ToList();
    }

    private int Count(Matrix<char> matrix)
    {
        var seaMonsterCount = 0;
        for (var y = 0; y < matrix.Height - _seaMonsterMatrix.Height; y++)
        {
            for (var x = 0; x < matrix.Width - _seaMonsterMatrix.Width; x++)
            {
                var foundSeaMonster = _seaMonsterHashAddresses.All(address => matrix.ReadValueAt(x + address.X, y + address.Y) == '#');
                seaMonsterCount += foundSeaMonster ? 1 : 0;
            }
        }

        return seaMonsterCount;
    }

    public int GetCount(Matrix<char> matrix)
    {
        foreach (var flip in _searchFlips)
        {
            matrix = flip(matrix);
            for (var i = 0; i < 4; i++)
            {
                matrix = matrix.RotateRight();

                var count = Count(matrix);
                if (count > 0)
                    return count;
            }
        }

        return 0;
    }
}
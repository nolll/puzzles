namespace Puzzles.Aoc.Puzzles.Aoc2021.Aoc202124;

public class Monad
{
    private readonly int[] _p3;
    private readonly int[] _p1;
    private readonly int[] _p2;
    private readonly long[] _zMax;

    public Monad()
    {
        _p1 = new[] { 12, 11, 14, -6, 15, 12, -9, 14, 14, -5, -9, -5, -2, -7 };
        _p2 = new[] { 4, 10, 12, 14, 6, 16, 1, 7, 8, 11, 8, 3, 1, 8 };
        _p3 = new[] { 1, 1, 1, 26, 1, 1, 26, 1, 1, 26, 26, 26, 26, 26 };
        _zMax = GetZLimits();
    }

    // z can't be larger than the product of p3[depth..] at each level
    private long[] GetZLimits()
    {
        var zList = new List<long>();
        long currentZMax = 1;
        foreach (var p in _p3.Reverse())
        {
            currentZMax *= p;
            zList.Add(currentZMax);
        }

        zList.Reverse();
        return zList.ToArray();
    }

    // this is the compiled validation process
    private long Process(int n, int w, long z)
    {
        var z1 = (long)Math.Floor((double)z / _p3[n]);
        if (w == z % 26 + _p1[n])
            return z1;

        return 26 * z1 + w + _p2[n];
    }

    // search recursively from most significant digit
    public void Search(int depth, long z, int[] solution, List<string> solutions)
    {
        // found valid solution
        if (depth == 14)
        {
            if (z == 0)
            {
                solutions.Add(string.Join("", solution));
            }
            return;
        }

        // if z is too large, abandon this branch
        if (z >= _zMax[depth])
            return;

        // continue with next digit
        for (var i = 1; i <= 9; ++i)
        {
            solution[depth] = i;
            Search(depth + 1, Process(depth, i, z), solution, solutions);
        }
    }
}

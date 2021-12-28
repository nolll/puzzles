using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Puzzles.Year2021.Day24;

public class Monad2
{
    private readonly int[] _params1;
    private readonly int[] _params2;
    private readonly int[] _params3;
    private readonly long[] _zMax;

    public Monad2()
    {
        _params1 = new[] { 1, 1, 1, 26, 1, 1, 26, 1, 1, 26, 26, 26, 26, 26 };
        _params2 = new[] { 12, 11, 11, -6, 15, 12, -9, 14, 14, -5, -9, -5, -2, -7 };
        _params3 = new[] { 4, 10, 10, 14, 6, 16, 1, 7, 8, 11, 8, 3, 1, 8 };
        var zList = new List<long>();
        long currentZMax = 1;
        foreach (var p in _params1.Reverse())
        {
            currentZMax *= p;
            zList.Add(currentZMax);
        }

        zList.Reverse();
        _zMax = zList.ToArray();
    }

    private long Process(int n, int w, long z)
    {
        var z1 = (long)Math.Floor((double)z / _params1[n]);
        if (w == z % 26 + _params2[n])
            return z1;

        return 26 * z1 + w + _params3[n];
    }

    public void Search(int depth, long z, int[] solution, List<string> solutions)
    {
        if (depth == 14)
        {
            if (z == 0)
            {
                solutions.Add(string.Join("", solution));
            }
            return;
        }
        else if (z >= _zMax[depth])
            return;

        for (var i = 1; i <= 9; ++i)
        {
            solution[depth] = i;
            Search(depth + 1, Process(depth, i, z), solution, solutions);
        }
    }
}

public class Monad
{
    private readonly Alu _alu;

    public Monad(string input)
    {
        _alu = new Alu(input);
    }

    public long Validate(long modelNumber)
    {
        var state = _alu.Process(modelNumber);
        return state.Memory['z'];
    }

    public long FindLargestValidNumber()
    {
        var modelNumber = 99_999_999_999_999;

        while (modelNumber > 0)
        {
            if(modelNumber % 1_000_000 == 0)
                Console.WriteLine(modelNumber);
            if (modelNumber.ToString().Contains('0'))
            {
                var result = _alu.Process2(modelNumber);
                if (result == 0)
                    return modelNumber;

            }

            modelNumber--;
        }

        return modelNumber;
    }
    
}
using System;

namespace Aoc.Puzzles.Aoc2019.Day01;

public class Module
{
    public int MassFuel { get; }
    public int TotalFuel { get; }

    public Module(int mass)
    {
        MassFuel = GetFuel(mass);
        TotalFuel = GetTotalFuel(mass);
    }

    private static int GetFuel(int mass)
    {
        return (int)Math.Floor((double)mass / 3) - 2;
    }

    private static int GetTotalFuel(int mass)
    {
        var totalFuel = 0;
        var fuel = GetFuel(mass);
            
        while (fuel > 0)
        {
            totalFuel += fuel;
            fuel = GetFuel(fuel);
        }

        return totalFuel;
    }
}
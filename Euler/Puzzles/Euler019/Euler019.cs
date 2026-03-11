using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler019;

[Name("Counting Sundays")]
public class Euler019 : EulerPuzzle
{
    [Puzzle("67c16f14538a051c5a6d1a2508e38851")]
    public int Solve() => Solve(DateTime.Parse("1901-01-01"), DateTime.Parse("2000-12-31"));

    public int Solve(DateTime startDate, DateTime endDate)
    {
        var firstSunday = startDate;
        while (firstSunday.DayOfWeek != DayOfWeek.Sunday)
        {
            firstSunday = firstSunday.AddDays(1);
        }

        var sundayCount = 0;
        var currentDate = firstSunday;
        while (currentDate < endDate)
        {
            if (currentDate.Day == 1) 
                sundayCount++;
            
            currentDate = currentDate.AddDays(7);
        }
            
        return sundayCount;
    }
}
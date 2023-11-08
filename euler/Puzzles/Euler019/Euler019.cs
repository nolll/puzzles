using Common.Puzzles;

namespace Euler.Puzzles.Euler019;

public class Euler019 : EulerPuzzle
{
    public override string Name => "Counting Sundays";

    protected override PuzzleResult Run()
    {
        var startDate = DateTime.Parse("1901-01-01");
        var endDate = DateTime.Parse("2000-12-31");
        var result = Run(startDate, endDate);
        return new PuzzleResult(result, "67c16f14538a051c5a6d1a2508e38851");
    }

    public int Run(DateTime startDate, DateTime endDate)
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
            {
                sundayCount++;
            }
            currentDate = currentDate.AddDays(7);
        }
            
        return sundayCount;
    }
}
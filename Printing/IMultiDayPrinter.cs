using Aoc.Platform;

namespace Aoc.Printing;

public interface IMultiDayPrinter
{
    void PrintHeader();
    void PrintDay(DayResult dayResult);
    void PrintFooter();
}
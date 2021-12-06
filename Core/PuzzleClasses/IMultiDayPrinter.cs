namespace Core.PuzzleClasses
{
    public interface IMultiDayPrinter
    {
        void PrintHeader();
        void PrintDay(DayResult dayResult);
        void PrintFooter();
    }
}
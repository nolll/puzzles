namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var daySelector = new DaySelector();
            var day = daySelector.GetDay();
            day.Run();
        }
    }
}

using Core.SantasShip;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day25 : Day2019
    {
        public Day25() : base(25)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var investigationDroid = new InvestigationDroid(FileInput);
            investigationDroid.Run();
        }
    }
}
using Core.SantasShip;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day25 : Day
    {
        public Day25() : base(25)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var investigationDroid = new InvestigationDroid(InputStrings.ComputerProgramDay25);
            investigationDroid.Run();
        }
    }
}
using ConsoleApp.Inputs;
using Core.Computer;

namespace ConsoleApp.Days
{
    public class Day05 : Day
    {
        public Day05() : base(5)
        {
        }

        protected override void RunDay()
        {
            var computer = new ConsoleComputer(InputData.ComputerProgramDay5);
            computer.Start();
        }
    }
}
using Core.SubmarineNavigation;

namespace ConsoleApp.Years.Year2021.Puzzles
{
    public class Day02 : Day2021
    {
        public Day02() : base(2)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var control = new SubmarineControl(FileInput, false);
            control.Move();
            
            return new PuzzleResult(control.Result, 1580000);
        }

        public override PuzzleResult RunPart2()
        {
            var control = new SubmarineControl(FileInput, true);
            control.Move();

            return new PuzzleResult(control.Result);
        }
    }
}
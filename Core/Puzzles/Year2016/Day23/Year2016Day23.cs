using Core.Platform;

namespace Core.Puzzles.Year2016.Day23
{
    public class Year2016Day23 : Year2016Day
    {
        public override string Comment => "Factorial of 12";
        public override bool IsSlow => true;

        public override int Day => 23;

        public override PuzzleResult RunPart1()
        {
            var computer = new SafeCrackingComputerPart1(FileInput, 7, 0);
            return new PuzzleResult(computer.ValueA, 12_748);
        }

        public override PuzzleResult RunPart2()
        {
            // By inspecting output from the computer I realized that it is calculating the factorial of 12
            var computer = new SafeCrackingComputerPart2(FileInput, 12, 0);
            return new PuzzleResult(computer.ValueA, 479_009_308);
        }
    }
}
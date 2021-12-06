using Core.Common.Computers.Operation;

namespace ConsoleApp.Puzzles.Year2018.Day21
{
    public class Year2018Day21 : Year2018Day
    {
        public override string Comment => "OpComputer";
        public override bool IsSlow => true;

        public override int Day => 21;

        public override PuzzleResult RunPart1()
        {
            var computer = new OpComputer();
            var result = computer.RunSpecialForDay21(FileInput, 0);
            return new PuzzleResult(result.first, 103_548);
        }

        public override PuzzleResult RunPart2()
        {
            var computer = new OpComputer();
            var result = computer.RunSpecialForDay21(FileInput, 0);
            return new PuzzleResult(result.last, 14_256_686);
        }
    }
}
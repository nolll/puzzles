namespace ConsoleApp.Puzzles.Year2015.Puzzles.Day23
{
    public class Year2015Day23 : Year2015Day
    {
        public override int Day => 23;

        public override PuzzleResult RunPart1()
        {
            var computer1 = new ChristmasComputer();
            computer1.Run(FileInput);
            return new PuzzleResult(computer1.RegisterB, 307);
        }

        public override PuzzleResult RunPart2()
        {
            var computer = new ChristmasComputer();
            computer.Run(FileInput, 1);
            return new PuzzleResult(computer.RegisterB, 160);
        }
    }
}
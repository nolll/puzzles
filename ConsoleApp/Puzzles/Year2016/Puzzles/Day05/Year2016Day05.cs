using Core.SecurityDoor;

namespace ConsoleApp.Puzzles.Year2016.Puzzles.Day05
{
    public class Year2016Day05 : Year2016Day
    {
        private readonly PasswordGenerator _generator = new();

        public override int Day => 5;
        
        public override PuzzleResult RunPart1()
        {
            var pwd = _generator.Generate1(Input);
            return new PuzzleResult(pwd, "2414bc77");
        }

        public override PuzzleResult RunPart2()
        {
            var pwd = _generator.Generate2(Input);
            return new PuzzleResult(pwd, "437e60fc");
        }

        private static string Input => "wtnhxymk";
    }
}
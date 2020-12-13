using System;
using Core.SecurityDoor;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day05 : Day2016
    {
        public Day05() : base(5)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var generator = new PasswordGenerator();
            var pwd = generator.Generate1(Input);
            return new PuzzleResult(pwd, "2414bc77");
        }

        public override PuzzleResult RunPart2()
        {
            var generator = new PasswordGenerator();
            var pwd = generator.Generate2(Input);
            return new PuzzleResult(pwd, "437e60fc");
        }

        private static string Input => "wtnhxymk";
    }
}
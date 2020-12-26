using System;
using Core.SecurityDoor;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day05 : Day2016
    {
        private readonly PasswordGenerator _generator;

        public Day05() : base(5)
        {
            _generator = new PasswordGenerator();
        }

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
using System;
using Core.Captcha;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day01 : Day2017
    {
        public Day01() : base(1)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var calc = new CaptchaCalculator(FileInput);
            return new PuzzleResult(calc.Sum1, 1177);
        }

        public override PuzzleResult RunPart2()
        {
            var calc = new CaptchaCalculator(FileInput);
            return new PuzzleResult(calc.Sum2, 1060);
        }
    }
}
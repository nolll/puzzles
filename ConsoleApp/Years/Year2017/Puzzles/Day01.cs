using System;
using Core.Captcha;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day01 : Day2017
    {
        public Day01() : base(1)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var calc = new CaptchaCalculator(FileInput);
            Console.WriteLine($"Captcha sum 1: {calc.Sum1}");

            WritePartTitle();
            Console.WriteLine($"Captcha sum 2: {calc.Sum2}");
        }
    }
}
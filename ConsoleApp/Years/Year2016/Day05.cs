using System;
using Core.SecurityDoor;

namespace ConsoleApp.Years.Year2016
{
    public class Day05 : Day
    {
        public Day05() : base(5)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var generator = new PasswordGenerator();
            var pwd1 = generator.Generate1(Input);
            Console.WriteLine($"Password 1: {pwd1}");

            WritePartTitle();
            var pwd2 = generator.Generate2(Input);
            Console.WriteLine($"Password 2: {pwd2}");
        }

        private const string Input = "wtnhxymk";
    }
}
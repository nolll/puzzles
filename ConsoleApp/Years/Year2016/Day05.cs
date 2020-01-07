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
            var pwd = generator.Generate(Input);
            Console.WriteLine($"Password: {pwd}");
        }

        private const string Input = "wtnhxymk";
    }
}
using System;
using Core.CorporatePolicy;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day11 : Day2015
    {
        public Day11() : base(11)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var validator = new CorporatePasswordValidator();
            var pwd = validator.FindNextPassword(LegacyInput);
            Console.WriteLine($"Next password 1: {pwd}");

            WritePartTitle();
            var pwd2 = validator.FindNextPassword(pwd);
            Console.WriteLine($"Next password 2: {pwd2}");
        }

        protected override string LegacyInput => "hxbxwxba";
    }
}
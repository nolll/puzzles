using System;
using Core.CorporatePolicy;

namespace ConsoleApp.Years.Year2015
{
    public class Day11 : Day
    {
        public Day11() : base(11)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var validator = new CorporatePasswordValidator();
            var pwd = validator.FindNextPassword(Input);
            Console.WriteLine($"Next password: {pwd}");
        }

        private const string Input = "hxbxwxba";
    }
}
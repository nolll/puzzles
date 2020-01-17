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
            var pwd = validator.FindNextPassword(Input1);
            Console.WriteLine($"Next password 1: {pwd}");

            WritePartTitle();
            var pwd2 = validator.FindNextPassword(pwd);
            Console.WriteLine($"Next password 2: {pwd2}");
        }

        private const string Input1 = "hxbxwxba";
    }
}
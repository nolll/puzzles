using System;
using Core.CorporatePolicy;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day11 : Day2015
    {
        private CorporatePasswordValidator _validator;
        private string _firstPassword;

        private CorporatePasswordValidator Validator => _validator ??= new CorporatePasswordValidator();
        private string FirstPassword => _firstPassword ??= Validator.FindNextPassword(Input);

        public Day11() : base(11)
        {
        }

        public override PuzzleResult RunPart1()
        {
            return new PuzzleResult($"Next password 1: {FirstPassword}");
        }

        public override PuzzleResult RunPart2()
        {
            var pwd2 = Validator.FindNextPassword(FirstPassword);
            return new PuzzleResult($"Next password 2: {pwd2}");
        }

        private const string Input = "hxbxwxba";
    }
}
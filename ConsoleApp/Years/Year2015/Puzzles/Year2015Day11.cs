using System;
using Core.CorporatePolicy;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Year2015Day11 : Year2015Day
    {
        private CorporatePasswordValidator _validator;
        private string _firstPassword;

        private CorporatePasswordValidator Validator => _validator ??= new CorporatePasswordValidator();
        private string FirstPassword => _firstPassword ??= Validator.FindNextPassword(Input);

        public override int Day => 11;

        public override PuzzleResult RunPart1()
        {
            return new PuzzleResult(FirstPassword, "hxbxxyzz");
        }

        public override PuzzleResult RunPart2()
        {
            var pwd2 = Validator.FindNextPassword(FirstPassword);
            return new PuzzleResult(pwd2, "hxcaabcc");
        }

        private const string Input = "hxbxwxba";
    }
}
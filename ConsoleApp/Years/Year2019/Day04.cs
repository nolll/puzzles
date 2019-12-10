using System;
using System.Linq;
using ConsoleApp.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day04 : Day
    {
        public Day04() : base(4)
        {
        }

        protected override void RunDay()
        {
            var passwordFinder = new Core.Passwords.PasswordFinder();
            var passwords = passwordFinder.Find(InputData.PasswordLowerbound, InputData.PasswordUpperbound);
            var passwordCount = passwords.Count();
            Console.WriteLine($"Number of valid passwords: {passwordCount}");
        }
    }
}
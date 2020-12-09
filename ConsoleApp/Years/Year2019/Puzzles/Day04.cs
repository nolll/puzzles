using System;
using System.Linq;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day04 : Day2019
    {
        public Day04() : base(4)
        {
        }

        protected override void RunDay()
        {
            var passwordBounds = Input.Split('-');
            var passwordLowerbound = int.Parse(passwordBounds[0]);
            var passwordUpperbound = int.Parse(passwordBounds[1]);
            
            var passwordFinder = new Core.Passwords.PasswordFinder();
            var passwords = passwordFinder.Find(passwordLowerbound, passwordUpperbound);
            var passwordCount = passwords.Count();
            Console.WriteLine($"Number of valid passwords: {passwordCount}");
        }

        private const string Input = "357253-892942";
    }
}
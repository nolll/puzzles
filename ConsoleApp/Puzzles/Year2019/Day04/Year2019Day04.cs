using System.Linq;
using Core.PuzzleClasses;

namespace ConsoleApp.Puzzles.Year2019.Day04
{
    public class Year2019Day04 : Year2019Day
    {
        public override int Day => 4;

        public override PuzzleResult RunPart1()
        {
            var passwordBounds = Input.Split('-');
            var passwordLowerbound = int.Parse(passwordBounds[0]);
            var passwordUpperbound = int.Parse(passwordBounds[1]);

            var passwordFinder = new PasswordFinder();
            var passwords = passwordFinder.FindPart1(passwordLowerbound, passwordUpperbound);
            var passwordCount = passwords.Count();
            return new PuzzleResult(passwordCount, 530);
        }

        public override PuzzleResult RunPart2()
        {
            var passwordBounds = Input.Split('-');
            var passwordLowerbound = int.Parse(passwordBounds[0]);
            var passwordUpperbound = int.Parse(passwordBounds[1]);

            var passwordFinder = new PasswordFinder();
            var passwords = passwordFinder.FindPart2(passwordLowerbound, passwordUpperbound);
            var passwordCount = passwords.Count();
            return new PuzzleResult(passwordCount, 324);
        }

        private const string Input = "357253-892942";
    }
}
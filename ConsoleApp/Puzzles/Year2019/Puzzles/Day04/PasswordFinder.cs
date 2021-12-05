using System.Collections.Generic;

namespace ConsoleApp.Puzzles.Year2019.Puzzles.Day04
{
    public class PasswordFinder
    {
        public IEnumerable<int> FindPart1(int lowerBound, int upperBound)
        {
            var passwordValidator = new PasswordValidator();

            for (var pwd = lowerBound; pwd <= upperBound; pwd++)
            {
                if (passwordValidator.IsValidPart1(pwd))
                    yield return pwd;
            }
        }

        public IEnumerable<int> FindPart2(int lowerBound, int upperBound)
        {
            var passwordValidator = new PasswordValidator();

            for (var pwd = lowerBound; pwd <= upperBound; pwd++)
            {
                if (passwordValidator.IsValidPart2(pwd))
                    yield return pwd;
            }
        }
    }
}
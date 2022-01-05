using System.Collections.Generic;

namespace Core.Puzzles.Year2019.Day04;

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
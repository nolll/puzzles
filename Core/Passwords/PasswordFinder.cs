using System.Collections.Generic;

namespace Core.Passwords
{
    public class PasswordFinder
    {
        public IEnumerable<int> Find(int lowerBound, int upperBound)
        {
            var passwordValidator = new PasswordValidator();

            for (var pwd = lowerBound; pwd <= upperBound; pwd++)
            {
                if (passwordValidator.IsValid(pwd))
                    yield return pwd;
            }
        }
    }
}
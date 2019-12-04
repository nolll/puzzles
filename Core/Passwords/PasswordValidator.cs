using System.Collections.Generic;
using System.Linq;

namespace Core.Passwords
{
    public class PasswordValidator
    {
        public bool IsValid(int pwd)
        {
            var chars = pwd.ToString().ToCharArray();
            var hasPair = HasPair(chars);
            if (!hasPair)
                return false;

            var hasCorrectOrder = HasCorrectOrder(chars);
            if (!hasCorrectOrder)
                return false;

            return true;
        }

        private static bool HasPair(IEnumerable<char> chars)
        {
            var lastChar = ' ';
            foreach (var c in chars.OrderBy(o => o))
            {
                if (c == lastChar)
                    return true;

                lastChar = c;
            }

            return false;
        }

        private static bool HasCorrectOrder(IEnumerable<char> chars)
        {
            var lastChar = ' ';
            foreach (var c in chars)
            {
                if (c < lastChar)
                    return false;

                lastChar = c;
            }

            return true;
        }
    }
}
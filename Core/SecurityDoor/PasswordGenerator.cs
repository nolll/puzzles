using System.Linq;
using System.Text;
using Core.Tools;

namespace Core.SecurityDoor
{
    public class PasswordGenerator
    {
        public string Generate1(string key)
        {
            var index = 1;
            var hashFactory = new Hashfactory();
            var compareString = GetCompareString(5);
            var pwd = new StringBuilder();
            while (pwd.Length < 8)
            {
                var hash = hashFactory.StringHashFromString($"{key}{index}");
                if (hash.StartsWith(compareString))
                {
                    pwd.Append(hash.Substring(5, 1));
                }

                index++;
            }

            return pwd.ToString().ToLower();
        }

        public string Generate2(string key)
        {
            var index = 1;
            var hashFactory = new Hashfactory();
            var compareString = GetCompareString(5);
            const int pwdLength = 8;
            var pwdArray = new char?[pwdLength];
            while (pwdArray.Count(o => o == null) > 0)
            {
                var hash = hashFactory.StringHashFromString($"{key}{index.ToString()}");
                if (hash.StartsWith(compareString))
                {
                    var result = hash.Substring(5, 2);
                    if (int.TryParse(result[0].ToString(), out var position))
                    {
                        if (position < pwdLength && pwdArray[position] == null)
                        {
                            pwdArray[position] = result[1];
                        }
                    }
                }

                index++;
            }

            var pwd = new StringBuilder();
            foreach (var c in pwdArray)
            {
                pwd.Append(c);
            }
            return pwd.ToString().ToLower();
        }

        private string GetCompareString(int leadingZeros)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < leadingZeros; i++)
            {
                sb.Append(0);
            }

            return sb.ToString();
        }
    }
}
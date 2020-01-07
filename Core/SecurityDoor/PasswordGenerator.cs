using System.Security.Cryptography;
using System.Text;

namespace Core.SecurityDoor
{
    public class PasswordGenerator
    {
        public string Generate(string key)
        {
            var index = 1;
            var md5 = MD5.Create();
            var compareString = GetCompareString(5);
            var pwd = new StringBuilder();
            while (pwd.Length < 8)
            {
                var hash = md5.ComputeHash(Encoding.ASCII.GetBytes($"{key}{index.ToString()}"));
                var sb = new StringBuilder();
                foreach (var b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                var hashString = sb.ToString();
                if (hashString.StartsWith(compareString))
                {
                    pwd.Append(hashString.Substring(5, 1));
                }

                index++;
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
using System.Security.Cryptography;
using System.Text;

namespace Core.Tools
{
    public class Hashfactory
    {
        private readonly MD5 _md5;

        public Hashfactory()
        {
            _md5 = MD5.Create();
        }

        public string Create(string str)
        {
            var hash = _md5.ComputeHash(Encoding.ASCII.GetBytes(str));
            var sb = new StringBuilder();
            foreach (var b in hash)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
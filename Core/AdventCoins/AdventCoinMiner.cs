using System.Security.Cryptography;
using System.Text;

namespace Core.AdventCoins
{
    public class AdventCoinMiner
    {
        public int Mine(string key)
        {
            var index = 1;
            int? coin = null;
            var md5 = MD5.Create();
            while(coin == null)
            {
                var hash = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes($"{key}{index.ToString()}"));
                var sb = new StringBuilder();
                foreach (var b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                var hashString = sb.ToString();
                if (hashString.StartsWith("00000"))
                {
                    coin = index;
                }

                index++;
            }

            return coin ?? 0;
        }
    }
}
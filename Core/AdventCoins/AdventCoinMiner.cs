using System.Security.Cryptography;
using System.Text;

namespace Core.AdventCoins
{
    public class AdventCoinMiner
    {
        public int Mine(string key, int leadingZeros)
        {
            var index = 1;
            int? coin = null;
            var md5 = MD5.Create();
            var compareString = GetCompareString(leadingZeros);
            while(coin == null)
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
                    coin = index;
                }

                index++;
            }

            return coin ?? 0;
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
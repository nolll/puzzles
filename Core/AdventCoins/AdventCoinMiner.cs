using System.Text;
using Core.Tools;

namespace Core.AdventCoins
{
    public class AdventCoinMiner
    {
        public int Mine(string key, int leadingZeros)
        {
            var index = 1;
            int? coin = null;
            var hashFactory = new Hashfactory();
            var compareString = GetCompareString(leadingZeros);
            while(coin == null)
            {
                var hash = hashFactory.Create($"{key}{index}");
                if (hash.StartsWith(compareString))
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
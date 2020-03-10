using System.Collections.Generic;
using System.Linq;

namespace Core.InfiniteElvesAndHouses
{
    public class PresentDelivery
    {
        public int Deliver(in int target)
        {
            var house = 1;

            while (true)
            {
                var factors = FindIntFactors(house);
                var presentCount = factors.Sum(o => o * 10);
                if (presentCount >= target)
                {
                    return house;
                }

                house++;
            }
        }

        private IEnumerable<int> FindIntFactors(int target)
        {
            var i = 1;
            while (i <= target)
            {
                if (target % i == 0)
                    yield return i;
                i++;
            }
        }
    }
}
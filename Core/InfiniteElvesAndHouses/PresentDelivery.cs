using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.InfiniteElvesAndHouses
{
    public class PresentDelivery
    {
        public int Deliver1(in int target)
        {
            var house = 1;

            while (true)
            {
                var factors = FindIntFactors1(house);
                var presentCount = factors.Sum(o => o * 10);
                if (presentCount >= target)
                {
                    return house;
                }

                house++;
            }
        }

        private IEnumerable<int> FindIntFactors1(int target)
        {
            var i = 1;
            while (i <= target / 2)
            {
                if (target % i == 0)
                    yield return i;
                i++;
            }

            yield return target;
        }

        public int Deliver2(in int target)
        {
            var houses = new Dictionary<int, int>();
            var elf = 1;

            while (elf <= target / 11)
            {
                var val = elf * 11;
                for (var house = elf; house <= elf * 50; house += elf)
                {
                    houses.TryGetValue(house, out var oldVal);
                    var totalVal = oldVal + val;
                    houses[house] = totalVal;
                }

                elf++;
            }

            foreach (var key in houses.Keys)
            {
                var value = houses[key];
                if (value >= target)
                    return key;
            }

            return 0;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Core.InfiniteElvesAndHouses
{
    public class PresentDelivery
    {
        private readonly Dictionary<int, IList<int>> _factors;

        public PresentDelivery()
        {
            _factors = new Dictionary<int, IList<int>>();
        }

        public int Deliver1(in int target)
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

        public IList<int> FindIntFactors(int target)
        {
            if (_factors.ContainsKey(target))
                return _factors[target];

            var factors = new List<int>();
            var i = target / 2;
            while (i > 0)
            {
                if (_factors.TryGetValue(i, out var cachedFactors))
                {
                    factors.AddRange(cachedFactors);
                    continue;
                }
                if (target % i == 0)
                    factors.Add(i);
                i--;
            }

            factors.Add(target);
            _factors.Add(target, factors);
            return factors.OrderBy(o => o).ToList();
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
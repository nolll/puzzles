using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Core.InfiniteElvesAndHouses
{
    public class PresentDelivery
    {
        public int Deliver1(in int target, bool useOptimization = false)
        {
            var house = FindLowerbound(target);
            
            while (true)
            {
                var hasAllLowFactors = !useOptimization || HasAllLowFactors(house);
                if (hasAllLowFactors)
                {
                    var factors = FindIntFactors(house);
                    var presentCount = factors.Sum(o => o * 10);
                    if (presentCount >= target)
                    {
                        return house;
                    }
                }
                
                house++;
            }
        }

        private int FindLowerbound(in int target)
        {
            var result = 0;
            var i = 1;
            while (true)
            {
                var nextResult = result + i * 10;

                if (nextResult > target)
                    return i;

                result = nextResult;
                
                i++;
            }
        }

        public IList<int> FindIntFactors(int target)
        {
            var factors = new List<int>();
            var i = target / 2;
            while (i > 0)
            {
                if (target % i == 0)
                {
                    factors.Add(i);
                }

                i--;
            }

            factors.Add(target);
            return factors;
        }

        private bool HasAllLowFactors(int target)
        {
            if (target % 2 != 0)
                return false;
            if (target % 3 != 0)
                return false;
            if (target % 5 != 0)
                return false;
            if (target % 7 != 0)
                return false;
            return true;
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
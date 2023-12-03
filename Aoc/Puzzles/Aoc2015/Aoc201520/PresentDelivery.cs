namespace Puzzles.Aoc.Puzzles.Aoc2015.Aoc201520;

public class PresentDelivery
{
    public int Deliver1(in int target, bool useOptimization)
    {
        var house = FindLowerbound(target);
        
        while (true)
        {
            var hasAllLowFactors = HasAllLowFactors(house);
            if (!useOptimization || hasAllLowFactors)
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
        if (target % 4 != 0)
            return false;
        if (target % 5 != 0)
            return false;
        if (target % 6 != 0)
            return false;
        if (target % 7 != 0)
            return false;
        if (target % 8 != 0)
            return false;
        if (target % 9 != 0)
            return false;
        if (target % 10 != 0)
            return false;
        return true;
    }

    public int Deliver2(in int target)
    {
        var houses = new int[target * 11];
        var elf = 1;

        while (elf <= target / 11)
        {
            var val = elf * 11;
            var house = elf;
            while(house <= elf * 50) 
            {
                houses[house] += val;
                house += elf;
            }

            elf++;
        }

        for(var house = 1; house < target; house++)
        {
            if (houses[house] >= target)
                return house;
        }

        return 0;
    }
}
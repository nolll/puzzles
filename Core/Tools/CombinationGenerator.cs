using System.Collections.Generic;
using System.Linq;

namespace Core.Tools
{
    public static class CombinationGenerator
    {
        public static List<List<T>> GetAllCombinations<T>(List<T> list)
        {
            var result = new List<List<T>> { new List<T>() };
            result.Last().Add(list[0]);
            if (list.Count == 1)
                return result;
            var tailCombos = GetAllCombinations(list.Skip(1).ToList());
            tailCombos.ForEach(combo =>
            {
                result.Add(new List<T>(combo));
                combo.Add(list[0]);
                result.Add(new List<T>(combo));
            });
            return result;
        }
    }
}
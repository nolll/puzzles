using System.Collections.Generic;
using System.Linq;

namespace Core.Tools
{
    public class PermutationGenerator
    {
        public IList<IEnumerable<int>> GetPermutations(IList<int> numbers)
        {
            return GetPermutations(numbers, numbers.Count).ToList();
        }

        public IList<IEnumerable<string>> GetPermutations(IList<string> strings)
        {
            return GetPermutations(strings, strings.Count()).ToList();
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IList<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
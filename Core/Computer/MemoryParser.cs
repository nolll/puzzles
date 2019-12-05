using System.Linq;

namespace Core.Computer
{
    public static class MemoryParser
    {
        public static int[] Parse(string input)
        {
            var data = input.Trim();
            var massStrings = data.Split(',');
            return massStrings.Select(int.Parse).ToArray();
        }
    }
}
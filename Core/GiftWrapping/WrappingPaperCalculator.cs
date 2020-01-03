using System.Collections.Generic;
using System.Linq;

namespace Core.GiftWrapping
{
    public class WrappingPaperCalculator
    {
        public int GetRequiredPaper(string input)
        {
            var gifts = input.Trim().Split('\n').Select(o => o.Trim());
            return gifts.Sum(GetRequiredPaperForOneBox);
        }

        public int GetRequiredPaperForOneBox(string input)
        {
            var dimensions = input.Split('x').Select(int.Parse).ToList();
            var sides = new List<int>
            {
                dimensions[0] * dimensions[1],
                dimensions[0] * dimensions[2],
                dimensions[1] * dimensions[2]
            }.OrderBy(o => o).ToList();

            return sides[0] * 3 + sides[1] * 2 + sides[2] * 2;
        }
    }
}
using System.Collections.Generic;

namespace App.Puzzles.Year2018.Day02
{
    public class IdCharacteristics
    {
        public bool HasDoubleChars { get; }
        public bool HasTripleChars { get; }

        public IdCharacteristics(string id)
        {
            var charCounts = new Dictionary<char, int>();
            foreach (var c in id)
            {
                if (!charCounts.TryAdd(c, 1))
                {
                    charCounts[c]++;
                }
            }

            foreach (var val in charCounts.Values)
            {
                if (val == 2)
                {
                    HasDoubleChars = true;
                }

                if (val == 3)
                {
                    HasTripleChars = true;
                }
            }
        }
    }
}
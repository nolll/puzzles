using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Lanternfish")]
public class Aoc202106 : AocPuzzle
{
    [Puzzle("f41058112a3490c1842a14e75ebfef8c")]
    public long Part1(string input) => new FishCounter(input).FishCountAfter(80);

    [Puzzle("d49cf732d5285745340ba70c6a3ddc15")]
    public long Part2(string input) => new FishCounter(input).FishCountAfter(256);
    
    public class FishCounter
    {
        private readonly List<int> _fishList;

        public FishCounter(string input)
        {
            _fishList = input.Split(',').Select(int.Parse).ToList();
        }

        public long FishCountAfter(int days)
        {
            var ages = new long[9];

            foreach (var fishAge in _fishList)
            {
                ages[fishAge]++;
            }

            var day = 0;
            while (day < days)
            {
                var zeros = ages[0];
                ages[0] = ages[1];
                ages[1] = ages[2];
                ages[2] = ages[3];
                ages[3] = ages[4];
                ages[4] = ages[5];
                ages[5] = ages[6];
                ages[6] = ages[7] + zeros;
                ages[7] = ages[8];
                ages[8] = zeros;

                day++;
            }

            return ages.Sum();
        }
    }
}
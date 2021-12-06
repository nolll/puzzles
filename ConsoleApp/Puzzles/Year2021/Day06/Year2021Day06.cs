using System.Linq;

namespace ConsoleApp.Puzzles.Year2021.Day06
{
    public class Year2021Day06 : Year2021Day
    {
        public override int Day => 6;

        public override PuzzleResult RunPart1()
        {
            var result = FishCount(FileInput, 80);
            return new PuzzleResult(result, 383_160);
        }

        public override PuzzleResult RunPart2()
        {
            var result = FishCount(FileInput, 256);
            return new PuzzleResult(result, 1_721_148_811_504);
        }

        public long FishCount(string input, int days)
        {
            var ages = new long[9];

            var fishList = input.Split(',').Select(int.Parse).ToList();
            foreach (var fishAge in fishList)
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
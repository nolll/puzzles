using System.Linq;
using Core.Tools;

namespace ConsoleApp.Puzzles.Year2021.Day06
{
    public class Year2021Day06 : Year2021Day
    {
        public override int Day => 6;

        public override PuzzleResult RunPart1()
        {
            var result = FishCount(FileInput, 80);
            return new PuzzleResult(result);
        }

        public override PuzzleResult RunPart2()
        {
            return new PuzzleResult(0);
        }

        public int FishCount(string input, int days)
        {
            var fishList = input.Split(',').Select(int.Parse).ToList();

            var day = 0;
            while (day < days)
            {
                var newFishCount = 0;
                for (var i = 0; i < fishList.Count; i++)
                {
                    fishList[i]--;
                    if (fishList[i] < 0)
                    {
                        fishList[i] = 6;
                        newFishCount++;
                    }
                }

                for (var j = 0; j < newFishCount; j++)
                {
                    fishList.Add(8);
                }
                
                day++;
            }
            
            return fishList.Count;
        }
    }
}
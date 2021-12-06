using Core.Platform;

namespace Core.Puzzles.Year2017.Day22
{
    public class Year2017Day22 : Year2017Day
    {
        public override int Day => 22;

        public override PuzzleResult RunPart1()
        {
            var infection1 = new VirusInfection(FileInput);
            var infectionCount1 = infection1.RunPart1(10_000);
            return new PuzzleResult(infectionCount1, 5538);
        }

        public override PuzzleResult RunPart2()
        {
            var infection2 = new VirusInfection(FileInput);
            var infectionCount2 = infection2.RunPart2(10_000_000);
            return new PuzzleResult(infectionCount2, 2_511_090);
        }
    }
}
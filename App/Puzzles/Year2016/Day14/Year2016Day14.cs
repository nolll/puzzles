using App.Platform;

namespace App.Puzzles.Year2016.Day14
{
    public class Year2016Day14 : Year2016Day
    {
        public override string Comment => "Slow hashing";
        public override bool IsSlow => true;

        public override int Day => 14;

        public override PuzzleResult RunPart1()
        {
            var generator = new KeyGenerator();
            var index = generator.GetIndexOf64ThKey(Input);
            
            return new PuzzleResult(index, 16_106);
        }

        public override PuzzleResult RunPart2()
        {
            var generator = new KeyGenerator();
            var index = generator.GetIndexOf64ThKey(Input, 2016);
            
            return new PuzzleResult(index, 22_423);
        }

        private static string Input => "zpqevtbw";
    }
}
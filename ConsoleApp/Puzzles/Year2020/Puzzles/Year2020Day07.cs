using Core.LuggageRules;

namespace ConsoleApp.Puzzles.Year2020.Puzzles
{
    public class Year2020Day07 : Year2020Day
    {
        public override int Day => 7;

        public override PuzzleResult RunPart1()
        {
            var processor = new LuggageProcessor(FileInput);
            var count1 = processor.NumberOfBagsThatCanContainGoldBags();
            return new PuzzleResult(count1, 272);
        }

        public override PuzzleResult RunPart2()
        {
            var processor = new LuggageProcessor(FileInput);
            var count2 = processor.NumberOfBagsThatAGoldBagContains();
            return new PuzzleResult(count2, 172246);
        }
    }
}
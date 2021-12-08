using App.Platform;

namespace App.Puzzles.Year2015.Day20
{
    public class Year2015Day20 : Year2015Day
    {
        public override string Comment => "Int factors";
        public override bool IsSlow => true;

        public override int Day => 20;

        public override PuzzleResult RunPart1()
        {
            var presentDelivery = new PresentDelivery();
            var house = presentDelivery.Deliver1(Input, true);
            return new PuzzleResult(house, 786_240);
        }

        public override PuzzleResult RunPart2()
        {
            var presentDelivery = new PresentDelivery();
            var house = presentDelivery.Deliver2(Input);
            return new PuzzleResult(house, 831_600);
        }

        private const int Input = 34_000_000;
    }
}
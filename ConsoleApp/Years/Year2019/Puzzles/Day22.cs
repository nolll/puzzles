using System;
using Core.CardShuffling;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day22 : Day2019
    {
        public Day22() : base(22)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var shuffler1 = new CardShuffler();
            var deck = shuffler1.Shuffle(10_007, FileInput);
            var positionOfCard2019 = deck.IndexOf(2019);
            var CardAtPosition2020 = deck[2020];
            Console.WriteLine($"Position of card 2019: {positionOfCard2019}");
            Console.WriteLine($"Card at position 2020: {CardAtPosition2020}");

            WritePartTitle();
            var shuffler2 = new CardShuffler();
            var cardAtPosition2020 = shuffler2.ShuffleBig(FileInput);
            Console.WriteLine($"Card at position 2020: {cardAtPosition2020}");
        }
    }
}
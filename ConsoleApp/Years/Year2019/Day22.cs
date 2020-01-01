using System;
using Core.CardShuffling;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day22 : Day
    {
        public Day22() : base(22)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var shuffler = new CardShuffler(10007);
            shuffler.Shuffle(InputData.CardShuffles);

            var position = shuffler.Deck.IndexOf(2019);

            Console.WriteLine($"Position of card 2019: {position}");
        }
    }
}
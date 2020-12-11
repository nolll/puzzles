using System;
using Core.CardShuffling;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day22 : Day2019
    {
        public Day22() : base(22)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var shuffler1 = new CardShuffler();
            var deck = shuffler1.Shuffle(10_007, FileInput);
            var positionOfCard2019 = deck.IndexOf(2019);
            return new PuzzleResult($"Position of card 2019: {positionOfCard2019}");
        }

        public override PuzzleResult RunPart2()
        {
            var shuffler2 = new CardShuffler();
            var cardAtPosition2020 = shuffler2.ShuffleBig(FileInput);
            return new PuzzleResult($"Card at position 2020: {cardAtPosition2020}");
        }
    }
}
using Core.CardCombat;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day22 : Day2020
    {
        public Day22() : base(22)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var game = new CardCombatGame(FileInput);
            var score = game.Play();
            return new PuzzleResult(score, 33_400);
        }

        public override PuzzleResult RunPart2()
        {
            var game = new CardCombatGame(FileInput);
            var score = game.PlayRecursive();
            return new PuzzleResult(score, 33_745);
        }
    }
}
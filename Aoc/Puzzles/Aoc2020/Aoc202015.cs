using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Rambunctious Recitation")]
public class Aoc202015 : AocPuzzle
{
    [Puzzle("9b1872aba49cfd16a3cc25436caa89e4")]
    public long Part1(string input) => new MemoryGame(input).Play(2020);

    [Puzzle("7bcf2e0ed295f1de70b3d5368e465107")]
    public long Part2(string input) => new MemoryGame(input).Play(30000000);
    
    public class MemoryGame
    {
        private readonly List<long> _inputNumbers;
        private readonly Dictionary<long, GameNumber> _numbers;

        public MemoryGame(string input)
        {
            _inputNumbers = input.Split(',').Select(long.Parse).ToList();
            _numbers = new Dictionary<long, GameNumber>();
        }

        public long Play(int until)
        {
            var turn = 0;
            GameNumber? lastSpokenNumber = null;
            foreach (var num in _inputNumbers)
            {
                lastSpokenNumber = Speak(num, turn);
                turn++;
            }

            if(lastSpokenNumber == null)
                throw new Exception("No number spoken");

            while (turn < until)
            {
                var numberToSpeak = lastSpokenNumber.SpeakCount == 1
                    ? 0
                    : lastSpokenNumber.Age;
                lastSpokenNumber = Speak(numberToSpeak, turn);
                turn++;
            }

            return lastSpokenNumber.Num;
        }

        private GameNumber Speak(long num, int turn)
        {
            if (!_numbers.TryGetValue(num, out var gameNum))
            {
                gameNum = new GameNumber(num);
                _numbers.Add(num, gameNum);
            }

            gameNum.Speak(turn);
            return gameNum;
        }

        private class GameNumber
        {
            private long _prevSpoken;
            private long _lastSpoken;
            
            public long Num { get; }
            public long SpeakCount { get; private set; }

            public GameNumber(long num)
            {
                _prevSpoken = 0;
                _lastSpoken = 0;
                Num = num;
                SpeakCount = 0;
            }

            public long Age => _lastSpoken - _prevSpoken;

            public void Speak(int time)
            {
                _prevSpoken = _lastSpoken;
                _lastSpoken = time;
                SpeakCount++;
            }
        }
    }
}
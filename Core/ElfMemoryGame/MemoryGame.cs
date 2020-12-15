using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.ElfMemoryGame
{
    public class MemoryGame
    {
        private readonly List<long> _inputNumbers;
        private Dictionary<long, GameNumber> _numbers;

        public MemoryGame(string input)
        {
            _inputNumbers = input.Split(',').Select(long.Parse).ToList();
            _numbers = new Dictionary<long, GameNumber>();
        }

        public long Play(int until)
        {
            var turn = 0;
            GameNumber lastSpokenNumber = null;
            foreach (var num in _inputNumbers)
            {
                lastSpokenNumber = Speak(num, turn);
                turn++;
            }

            if(lastSpokenNumber == null)
                throw new Exception("No number spoken");

            while (turn < until)
            {
                if (lastSpokenNumber.SpeakCount == 1)
                {
                    lastSpokenNumber = Speak(0, turn);
                }
                else
                {
                    lastSpokenNumber = Speak(lastSpokenNumber.Age, turn);
                }
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
            public long Num { get; }
            public long PrevSpoken { get; private set; }
            public long LastSpoken { get; private set; }
            public long SpeakCount { get; private set; }

            public GameNumber(long num)
            {
                Num = num;
                PrevSpoken = 0;
                LastSpoken = 0;
                SpeakCount = 0;
            }

            public long Age => LastSpoken - PrevSpoken;

            public void Speak(int time)
            {
                PrevSpoken = LastSpoken;
                LastSpoken = time;
                SpeakCount++;
            }
        }
    }
}
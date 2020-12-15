using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.ElfMemoryGame
{
    public class MemoryGame
    {
        private readonly List<int> _inputNumbers;
        private Dictionary<int, GameNumber> _numbers;

        public MemoryGame(string input)
        {
            _inputNumbers = input.Split(',').Select(int.Parse).ToList();
            _numbers = new Dictionary<int, GameNumber>();
        }

        public int Play()
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

            while (turn < 2020)
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

        private GameNumber Speak(int num, int turn)
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
            public int Num { get; }
            public int PrevSpoken { get; private set; }
            public int LastSpoken { get; private set; }
            public int SpeakCount { get; private set; }

            public GameNumber(int num)
            {
                Num = num;
                PrevSpoken = 0;
                LastSpoken = 0;
                SpeakCount = 0;
            }

            public int Age => LastSpoken - PrevSpoken;

            public void Speak(int time)
            {
                PrevSpoken = LastSpoken;
                LastSpoken = time;
                SpeakCount++;
            }
        }
    }
}
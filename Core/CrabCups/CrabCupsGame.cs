using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.CrabCups
{
    public class CrabCupsGame
    {
        private LinkedList<int> _circle;
        private LinkedListNode<int> _currentCup;
        private List<int> _numbers;
        private int _minNumber;
        private int _maxNumber;

        public CrabCupsGame(int input)
        {
            _numbers = input.ToString().ToCharArray().Select(o => int.Parse((string) o.ToString())).ToList();
            _minNumber = _numbers.Min();
            _maxNumber = _numbers.Max();
            _circle = new LinkedList<int>();

            do
            {
                var num = _numbers.First();
                _currentCup = _circle.AddLast(num);
                _numbers.RemoveAt(0);
            } while (_numbers.Any());

            _currentCup = _circle.First;
        }

        public string Play(int moves)
        {
            for (var i = 0; i < moves; i++)
            {
                var currentCupBeforeMove = _currentCup;
                var currentCupLabel = _currentCup.Value;
                var firstCupToMove = _currentCup.NextOrFirst();
                var cupsToMove = new List<int>();
                for (var j = 0; j < 3; j++)
                {
                    cupsToMove.Add(firstCupToMove.Value);
                    var nextCupToMove = firstCupToMove.NextOrFirst();
                    _circle.Remove(firstCupToMove);
                    firstCupToMove = nextCupToMove;
                }

                var destinationCup = currentCupLabel - 1;
                while (destinationCup < _minNumber || cupsToMove.Contains(destinationCup))
                {
                    destinationCup--;
                    if (destinationCup < _minNumber)
                        destinationCup = _maxNumber;
                }

                while (_currentCup.Value != destinationCup)
                {
                    MoveForward();
                }

                foreach (var cup in cupsToMove)
                {
                    _circle.AddAfter(_currentCup, cup);
                    MoveForward();
                }

                _currentCup = currentCupBeforeMove;
                MoveForward();
            }

            while (_currentCup.Value != 1)
            {
                MoveForward();
            }

            var resultNumbers = new List<int>();
            MoveForward();
            while (_currentCup.Value != 1)
            {
                resultNumbers.Add(_currentCup.Value);
                MoveForward();
            }

            return string.Join("", resultNumbers.Select(o => o.ToString()));
        }

        private void Move(int distance)
        {
            if (distance < 0)
                MoveBack(Math.Abs(distance));

            MoveForward(distance);
        }

        private void MoveBack(int distance = 1)
        {
            while (distance > 0)
            {
                _currentCup = _currentCup.PreviousOrLast();
                distance--;
            }
        }

        private void MoveForward(int distance = 1)
        {
            while (distance > 0)
            {
                _currentCup = _currentCup.NextOrFirst();
                distance--;
            }
        }
    }
}
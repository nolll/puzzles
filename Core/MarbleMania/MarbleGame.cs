using System.Collections.Generic;
using System.Linq;

namespace Core.MarbleMania
{
    public class MarbleGame
    {
        private readonly long[] _playerScores;
        private readonly LinkedList<int> _circle;
        private LinkedListNode<int> _currentMarble;
        private readonly int _currentPlayer;
        private readonly int _marbleValue;
        public long WinnerScore { get; }

        public MarbleGame(int playerCount, int lastMarbleValue)
        {
            _playerScores = new long[playerCount];
            _circle = new LinkedList<int>();
            _currentMarble = _circle.AddFirst(0);
            _currentPlayer = 0;
            _marbleValue = 0;
            
            while (_marbleValue < lastMarbleValue)
            {
                _marbleValue++;
                if (_marbleValue % 23 == 0)
                {
                    MoveBack(7);
                    _playerScores[_currentPlayer] += _marbleValue + _currentMarble.Value;
                    var removeThis = _currentMarble;
                    Next();
                    _circle.Remove(removeThis);
                }
                else
                {
                    Next();
                    _currentMarble = _circle.AddAfter(_currentMarble, _marbleValue);
                }

                _currentPlayer++;
                if (_currentPlayer >= _playerScores.Length)
                    _currentPlayer = 0;
            }

            WinnerScore = _playerScores.Max();
        }

        private void MoveBack(int distance)
        {
            while (distance > 0)
            {
                Previous();
                distance--;
            }
        }

        private void Previous()
        {
            _currentMarble = _currentMarble.Previous ?? _circle.Last;
        }

        private void Next()
        {
            _currentMarble = _currentMarble.Next ?? _circle.First;
        }
    }
}
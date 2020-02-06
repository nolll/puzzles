using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.MarbleMania
{
    public class MarbleGame
    {
        private LinkedListNode<int> _currentMarble;
        private long[] _playerScores;
        private LinkedList<int> _circle;
        private int _currentPlayer;
        private int _marbleValue;
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
                    _currentMarble = _currentMarble.NextOrFirst();
                    _circle.Remove(removeThis);
                }
                else
                {
                    _currentMarble = _currentMarble.NextOrFirst();
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
                _currentMarble = _currentMarble.PreviousOrLast();
                distance--;
            }
        }
    }
}
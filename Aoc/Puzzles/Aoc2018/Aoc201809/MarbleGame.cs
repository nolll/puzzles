using Pzl.Tools.Lists;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201809;

public class MarbleGame
{
    private LinkedListNode<int> _currentMarble;
    private readonly LinkedList<int> _circle;
    private readonly int _currentPlayer;
    private readonly int _marbleValue;
    public long WinnerScore { get; }

    public static MarbleGame Parse(string input, int marbleValueMultiplier = 1)
    {
        var words = input.Split(' ');
        var playerCount = int.Parse(words.First());
        var lastMarbleValue = int.Parse(words[6]) * marbleValueMultiplier;

        return new MarbleGame(playerCount, lastMarbleValue);
    }

    public MarbleGame(int playerCount, int lastMarbleValue)
    {
        var playerScores = new long[playerCount];
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
                playerScores[_currentPlayer] += _marbleValue + _currentMarble.Value;
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
            if (_currentPlayer >= playerScores.Length)
                _currentPlayer = 0;
        }

        WinnerScore = playerScores.Max();
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
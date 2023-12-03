using Puzzles.Common.Lists;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202023;

public class CrabCupsGame
{
    private const int ExtendedMaxNumber = 1_000_000;

    private readonly LinkedList<int> _circle;
    private LinkedListNode<int> _currentCup = new(0);
    private readonly int _minNumber;
    private readonly int _maxNumber;
    private readonly Dictionary<int, LinkedListNode<int>> _dictionary;

    public CrabCupsGame(int input, bool isExtended = false)
    {
        var numbers = input.ToString().ToCharArray().Select(o => int.Parse((string) o.ToString())).ToList();
        _minNumber = numbers.Min();
        _maxNumber = numbers.Max();
        _circle = new LinkedList<int>();
        _dictionary = new Dictionary<int, LinkedListNode<int>>();

        do
        {
            var num = numbers.First();
            _currentCup = _circle.AddLast(num);
            _dictionary.Add(num, _currentCup);
            numbers.RemoveAt(0);
        } while (numbers.Any());

        if (isExtended)
        {
            for (var num = _maxNumber + 1; num <= ExtendedMaxNumber; num++)
            {
                _currentCup = _circle.AddLast(num);
                _dictionary.Add(num, _currentCup);
            }

            _maxNumber = ExtendedMaxNumber;
        }

        _currentCup = _circle.First!;
    }

    public void Play(int moves)
    {
        var cupsToMove = new LinkedListNode<int>[3];
        for (var i = 0; i < moves; i++)
        {
            var currentCupBeforeMove = _currentCup;
            var currentCupLabel = _currentCup.Value;
            var nodeToMove = _currentCup.NextOrFirst();
            for (var j = 0; j < 3; j++)
            {
                cupsToMove[j] = nodeToMove;
                var nodeToRemove = nodeToMove;
                nodeToMove = nodeToMove.NextOrFirst();
                _circle.Remove(nodeToRemove);
            }

            var destinationCup = currentCupLabel - 1;
            while (destinationCup < _minNumber || cupsToMove.Any(o => o.Value == destinationCup))
            {
                destinationCup--;
                if (destinationCup < _minNumber)
                    destinationCup = _maxNumber;
            }

            _currentCup = _dictionary[destinationCup];

            foreach (var cup in cupsToMove)
            {
                _circle.AddAfter(_currentCup, cup);
                _currentCup = _currentCup.NextOrFirst();
            }

            _currentCup = currentCupBeforeMove;
            _currentCup = _currentCup.NextOrFirst();
        }
    }

    public string ResultString
    {
        get
        {
            _currentCup = _dictionary[1];

            var resultNumbers = new List<int>();
            _currentCup = _currentCup.NextOrFirst();
            while (_currentCup.Value != 1)
            {
                resultNumbers.Add(_currentCup.Value);
                _currentCup = _currentCup.NextOrFirst();
            }

            return string.Join("", resultNumbers.Select(o => o.ToString()));
        }
    }

    public long ResultProduct
    {
        get
        {
            _currentCup = _dictionary[1];

            _currentCup = _currentCup.NextOrFirst();
            long val1 = _currentCup.Value;
            _currentCup = _currentCup.NextOrFirst();
            long val2 = _currentCup.Value;

            return val1 * val2;
        }
    }
}
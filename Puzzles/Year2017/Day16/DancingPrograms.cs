using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Year2017.Day16;

public class DancingPrograms
{
    private IDictionary<char, int> _positions;
    public int RepeatAfter { get; private set; }

    public DancingPrograms(string programs = "abcdefghijklmnop")
    {
        Init(programs);
    }

    private void Init(string programs)
    {
        _positions = new Dictionary<char, int>();
        var index = 0;
        foreach (var c in programs)
        {
            _positions.Add(c, index);
            index++;
        }
    }

    public string Programs
    {
        get
        {
            var arr = new char[_positions.Count];
            foreach (var key in _positions.Keys)
            {
                arr[_positions[key]] = key;
            }

            return string.Concat(arr);
        }
    }

    public void Dance(string input, int iterations)
    {
        var moves = ParseMoves(input);
        var repeatPeriod = GetRepeatPeriod(moves);
        for (var i = 0; i < iterations % repeatPeriod; i++)
        {
            foreach (var move in moves)
                move.Execute(_positions);
        }
    }

    private int GetRepeatPeriod(IList<DanceMove> moves)
    {
        var i = 0;
        var startPrograms = Programs;
        while (true)
        {
            foreach (var move in moves)
                move.Execute(_positions);

            i++;
            if (Programs == startPrograms)
                return i;
        }
    }

    private IList<DanceMove> ParseMoves(string input)
    {
        return input.Split(',').Select(ParseMove).ToList();
    }

    private DanceMove ParseMove(string s)
    {
        var command = s.First();
        if (command == 's')
            return new SpinMove(s);
        if (command == 'x')
            return new ExchangeMove(s);
        if (command == 'p')
            return new PartnerMove(s);
        return new EmptyMove();
    }
}
using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2017.Day25;

public class TuringMachine
{
    private readonly char _startState;
    private readonly int _steps;
    private readonly Dictionary<char, TuringState> _states;
    private readonly LinkedList<int> _tape;
    private LinkedListNode<int> _cursor;

    public TuringMachine(string input)
    {
        _tape = new LinkedList<int>();
        _cursor = _tape.AddFirst(0);

        var rows = PuzzleInputReader.ReadLines(input.Replace("-", "").Replace(".", "").Replace(":", ""));

        var beginRow = rows[0];
        _startState = beginRow.Split(' ')[3].First();

        var stepsRow = rows[1];
        _steps = int.Parse(stepsRow.Split(' ')[5]);

        _states = new Dictionary<char, TuringState>();
        var stateRows = rows.Skip(2).ToList();
        while (stateRows.Any())
        {
            var currentRows = stateRows.Take(10).ToList();

            var stateRow = currentRows[1].Trim();
            var state = stateRow.Split(' ')[2].First();

            var zeroValueRow = currentRows[3].Trim();
            var zeroValue = int.Parse(zeroValueRow.Split(' ')[3].Substring(0, 1));

            var zeroMoveRow = currentRows[4].Trim();
            var zeroMove = zeroMoveRow.Split(' ')[5] == "left" ? -1 : 1;

            var zeroNextRow = currentRows[5].Trim();
            var zeroNext = zeroNextRow.Split(' ')[3].First();

            var oneValueRow = currentRows[7].Trim();
            var oneValue = int.Parse(oneValueRow.Split(' ')[3].Substring(0, 1));

            var oneMoveRow = currentRows[8].Trim();
            var oneMove = oneMoveRow.Split(' ')[5] == "left" ? -1 : 1;

            var oneNextRow = currentRows[9].Trim();
            var oneNext = oneNextRow.Split(' ')[3].First();

            var turingState = new TuringState(state, zeroValue, zeroMove, zeroNext, oneValue, oneMove, oneNext);
            _states.Add(state, turingState);

            stateRows = stateRows.Skip(10).ToList();
        }
    }

    public int Run()
    {
        var currentState = _startState;
        for (var i = 0; i < _steps; i++)
        {
            var state = _states[currentState];
            currentState = ApplyState(state);
        }

        return _tape.Sum();
    }

    private char ApplyState(TuringState state)
    {
        return _cursor.Value == 0
            ? ApplyForZero(state)
            : ApplyForOne(state);
    }

    private char ApplyForZero(TuringState state)
    {
        return Apply(state.ValueIfZero, state.DirectionIfZero, state.NextStateIfZero);
    }

    private char ApplyForOne(TuringState state)
    {
        return Apply(state.ValueIfOne, state.DirectionIfOne, state.NextStateIfOne);
    }

    private char Apply(int value, int direction, char nextState)
    {
        _cursor.Value = value;
        _cursor = direction == 1 
            ? _cursor.Next ?? _tape.AddLast(0) 
            : _cursor.Previous ?? _tape.AddFirst(0);

        return nextState;
    }
}
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.TuringDiagnostics
{
    public class TuringMachine
    {
        private readonly char _startState;
        private readonly int _steps;
        private readonly Dictionary<char, TuringState> _states;

        public TuringMachine(string input)
        {
            var rows = PuzzleInputReader.Read(input.Replace("-", "").Replace(".", "").Replace(":", ""));

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
            var tape = new LinkedList<int>();
            var cursor = tape.AddFirst(0);
            var currentState = _startState;
            for (int i = 0; i < _steps; i++)
            {
                var state = _states[currentState];
                if (cursor.Value == 0)
                {
                    cursor.Value = state.ValueIfZero;
                    if (state.DirectionIfZero == 1)
                    {
                        cursor = cursor.Next;
                        if (cursor == null)
                            cursor = tape.AddLast(0);
                    }
                    else
                    {
                        cursor = cursor.Previous;
                        if (cursor == null)
                            cursor = tape.AddFirst(0);
                    }

                    currentState = state.NextStateIfZero;
                }
                else
                {
                    cursor.Value = state.ValueIfOne;
                    if (state.DirectionIfOne == 1)
                    {
                        cursor = cursor.Next;
                        if (cursor == null)
                            cursor = tape.AddLast(0);
                    }
                    else
                    {
                        cursor = cursor.Previous;
                        if (cursor == null)
                            cursor = tape.AddFirst(0);
                    }

                    currentState = state.NextStateIfOne;
                }
            }

            return tape.Sum();
        }
    }
}
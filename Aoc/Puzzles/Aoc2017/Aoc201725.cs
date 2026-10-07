using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("The Halting Problem")]
public class Aoc201725 : AocPuzzle
{
    [Puzzle("a18cb67e5cdfb9d5e9a4afd12de0d627")]
    public int Part1(string input)
    {
        var tape = new LinkedList<int>();
        var cursor = tape.AddFirst(0);
        var (startState, steps, states) = Parse(input);

        var currentState = startState;
        for (var i = 0; i < steps; i++)
        {
            var state = states[currentState];
            currentState = ApplyState(state);
        }

        return tape.Sum();

        char ApplyState(TuringState state) => cursor.Value == 0
            ? ApplyForZero(state)
            : ApplyForOne(state);

        char ApplyForZero(TuringState state) =>
            Apply(state.ValueIfZero, state.DirectionIfZero, state.NextStateIfZero);

        char ApplyForOne(TuringState state) =>
            Apply(state.ValueIfOne, state.DirectionIfOne, state.NextStateIfOne);

        char Apply(int value, int direction, char nextState)
        {
            cursor.Value = value;
            cursor = direction == 1
                ? cursor.Next ?? tape.AddLast(0)
                : cursor.Previous ?? tape.AddFirst(0);

            return nextState;
        }
    }

    private static (char, int, Dictionary<char, TuringState>) Parse(string input)
    {
        var rows = input.Replace("-", "").Replace(".", "").Replace(":", "").Split(LineBreaks.Single);

        var beginRow = rows[0];
        var startState = beginRow.Split(' ')[3].First();

        var stepsRow = rows[1];
        var steps = int.Parse(stepsRow.Split(' ')[5]);

        var states = new Dictionary<char, TuringState>();
        var stateRows = rows.Skip(2).ToList();
        while (stateRows.Count != 0)
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

            var turingState = new TuringState(zeroValue, zeroMove, zeroNext, oneValue, oneMove, oneNext);
            states.Add(state, turingState);

            stateRows = stateRows.Skip(10).ToList();
        }

        return (startState, steps, states);
    }

    private record TuringState(
        int ValueIfZero,
        int DirectionIfZero,
        char NextStateIfZero,
        int ValueIfOne,
        int DirectionIfOne,
        char NextStateIfOne);
}
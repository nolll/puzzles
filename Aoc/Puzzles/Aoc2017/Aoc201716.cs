using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Permutation Promenade")]
public class Aoc201716 : AocPuzzle
{
    [Puzzle("54e5dfe8c4867e76716033345f70c9ad")]
    public string Part1(string input) => Dance(input, 1);

    [Puzzle("023321046c58453f7009348c8a83a89c")]
    public string Part2(string input) => Dance(input, 1_000_000_000);

    public string Dance(string input, int iterations, string programs = "abcdefghijklmnop")
    {
        var positions = GetPositions(programs);
        var moves = ParseMoves(input);
        var repeatPeriod = GetRepeatPeriod(positions, moves);
        for (var i = 0; i < iterations % repeatPeriod; i++)
        {
            foreach (var move in moves)
                move.Execute(positions);
        }

        return GetPrograms(positions);
    }
    
    private static Dictionary<char, int> GetPositions(string programs)
    {
        var positions = new Dictionary<char, int>();
        var index = 0;
        foreach (var c in programs)
        {
            positions.Add(c, index);
            index++;
        }

        return positions;
    }

    public static string GetPrograms(Dictionary<char, int> positions)
    {
        var arr = new char[positions.Count];
        foreach (var key in positions.Keys)
        {
            arr[positions[key]] = key;
        }

        return string.Concat(arr);
    }

    private static int GetRepeatPeriod(Dictionary<char, int> positions, IList<DanceMove> moves)
    {
        var i = 0;
        var startPrograms = GetPrograms(positions);
        while (true)
        {
            foreach (var move in moves)
                move.Execute(positions);

            i++;
            if (GetPrograms(positions) == startPrograms)
                return i;
        }
    }

    private static DanceMove[] ParseMoves(string input) => [.. input.Split(',').Select(ParseMove)];

    private static DanceMove ParseMove(string s) => s.First() switch
    {
        's' => new SpinMove(s),
        'x' => new ExchangeMove(s),
        'p' => new PartnerMove(s),
        _ => new EmptyMove()
    };

    private abstract class DanceMove
    {
        public abstract void Execute(IDictionary<char, int> programs);
    }

    private class EmptyMove : DanceMove
    {
        public override void Execute(IDictionary<char, int> programs)
        {
        }
    }

    private class ExchangeMove : DanceMove
    {
        private readonly int _index1;
        private readonly int _index2;

        public ExchangeMove(string command)
        {
            var parts = command[1..].Split('/');
            _index1 = int.Parse(parts[0]);
            _index2 = int.Parse(parts[1]);
        }

        public override void Execute(IDictionary<char, int> programs)
        {
            char? key1 = null;
            char? key2 = null;
            foreach (var key in programs.Keys)
            {
                if (programs[key] == _index1)
                    key1 = key;

                if (programs[key] == _index2)
                    key2 = key;
            }

            programs[key1!.Value] = _index2;
            programs[key2!.Value] = _index1;
        }
    }

    private class PartnerMove : DanceMove
    {
        private readonly char _val1;
        private readonly char _val2;

        public PartnerMove(string command)
        {
            var parts = command[1..].Split('/').Select(o => o.First()).ToList();
            _val1 = parts[0];
            _val2 = parts[1];
        }

        public override void Execute(IDictionary<char, int> programs)
        {
            var index1 = programs[_val1];
            var index2 = programs[_val2];
            programs[_val1] = index2;
            programs[_val2] = index1;
        }
    }

    private class SpinMove(string command) : DanceMove
    {
        private readonly int _itemsToMove = int.Parse(command[1..]);

        public override void Execute(IDictionary<char, int> programs)
        {
            var programCount = programs.Count;
            var keys = programs.Keys.ToList();
            foreach (var key in keys)
            {
                var pos = programs[key];
                var newPos = pos + _itemsToMove;
                if (newPos > programCount - 1)
                    newPos -= programCount;
                programs[key] = newPos;
            }
        }
    }
}
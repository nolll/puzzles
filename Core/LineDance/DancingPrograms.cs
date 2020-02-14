using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.LineDance
{
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

    public abstract class DanceMove
    {
        public abstract void Execute(IDictionary<char, int> programs);
    }

    public class SpinMove : DanceMove
    {
        private readonly int _itemsToMove;

        public SpinMove(string command)
        {
            _itemsToMove = int.Parse(command.Substring(1));
        }

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

    public class ExchangeMove : DanceMove
    {
        private readonly int _index1;
        private readonly int _index2;

        public ExchangeMove(string command)
        {
            var parts = command.Substring(1).Split('/');
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

            programs[key1.Value] = _index2;
            programs[key2.Value] = _index1;
        }
    }

    public class PartnerMove : DanceMove
    {
        private readonly char _val1;
        private readonly char _val2;

        public PartnerMove(string command)
        {
            var parts = command.Substring(1).Split('/').Select(o => o.First()).ToList();
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

    public class EmptyMove : DanceMove
    {
        public override void Execute(IDictionary<char, int> programs)
        {
        }
    }
}
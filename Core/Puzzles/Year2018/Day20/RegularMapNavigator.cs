using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems;

namespace Core.Puzzles.Year2018.Day20
{
    public class RegularMapNavigator
    {
        private readonly Matrix<char> _map;
        private readonly IDictionary<MatrixAddress, int> _distances;

        private static class Chars
        {
            public const char Start = '^';
            public const char End = '$';
            public const char North = 'N';
            public const char East = 'E';
            public const char South = 'S';
            public const char Room = '.';
            public const char Wall = '#';
            public const char Next = '|';
            public const char GroupStart = '(';
            public const char GroupEnd = ')';
        }

        public int MostDoors { get; }
        public int RoomsMoreThat1000DoorsAway { get; }

        public RegularMapNavigator(string input)
        {
            MostDoors = 0;
            const int size = 220;
            const int start = size / 2;
            _map = new Matrix<char>(size, size, Chars.Wall);
            _distances = new Dictionary<MatrixAddress, int>();
            var startAddress = new MatrixAddress(start, start);
            _map.MoveTo(startAddress);
            BuildMap(input);
            MostDoors = _distances.Values.OrderBy(o => o).Last();
            RoomsMoreThat1000DoorsAway = _distances.Values.Count(o => o >= 1000);
        }
        
        private void BuildMap(string input)
        {
            input = input.TrimEnd(Chars.End).TrimStart(Chars.Start);
            _distances[_map.Address] = 0;
            _map.WriteValue(Chars.Room);
            var queue = new Stack<MatrixAddress>();
            foreach (var c in input)
            {
                if (c == Chars.GroupStart)
                    queue.Push(_map.Address);
                else if (c == Chars.GroupEnd)
                    _map.MoveTo(queue.Pop());
                else if (c == Chars.Next)
                    _map.MoveTo(queue.Peek());
                else
                    Move(c);
            }
        }

        private void Move(char c)
        {
            var lastDistance = _distances[_map.Address];
            var move = GetMoveFunc(c);
            move();
            _map.WriteValue(Chars.Room);
            move();
            if (_map.ReadValue() == Chars.Wall)
            {
                _map.WriteValue(Chars.Room);
            }

            var distance = lastDistance + 1;
            _distances[_map.Address] = _distances.TryGetValue(_map.Address, out var existingDistance)
                ? Math.Min(distance, existingDistance)
                : distance;
        }

        private Action GetMoveFunc(char c)
        {
            if (c == Chars.North)
                return MoveNorth;
            if (c == Chars.East)
                return MoveEast;
            if (c == Chars.South)
                return MoveSouth;
            return MoveWest;
        }

        private void MoveNorth() => _map.MoveUp();
        private void MoveEast() => _map.MoveRight();
        private void MoveSouth() => _map.MoveDown();
        private void MoveWest() => _map.MoveLeft();
    }
}
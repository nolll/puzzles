using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class RegularMapTests
    {
        [TestCase("^WNE$", 3)]
        [TestCase("^ENWWW(NEEE|SSE(EE|N))$", 10)]
        [TestCase("^ENNWSWW(NEWS|)SSSEEN(WNSE|)EE(SWEN|)NNN$", 18)]
        public void FindRoomThatRequiresMostDoors(string regex, int doorCount)
        {
            var regexMap = new RegularMap(regex);

            Assert.That(regexMap.MostDoors, Is.EqualTo(doorCount));
        }
    }

    public class RegularMap
    {
        private readonly Matrix<char> _map;
        private readonly IList<MatrixAddress> _rooms;

        private static class Chars
        {
            public const char Start = '^';
            public const char End = '$';
            public const char North = 'N';
            public const char East = 'E';
            public const char South = 'S';
            public const char West = 'W';
            public const char Room = '.';
            public const char Wall = '#';
            public const char Door = 'D';
            public const char GroupStart = '(';
            public const char GroupEnd = ')';
        }

        public int MostDoors { get; }

        public RegularMap(string input)
        {
            MostDoors = 0;
            _map = new Matrix<char>(1, 1, ' ');
            _rooms = new List<MatrixAddress>();
            BuildMap(input);
            var stepCounts = _rooms.Select(o => PathFinder.StepCountTo(_map, _map.StartAddress, o));
            MostDoors = stepCounts.OrderByDescending(o => o).First() / 2;
        }

        private void BuildMap(string input)
        {
            _map.WriteValue(Chars.Room);
            var stringsToProcess = ParseRegex(input);
            foreach (var s in stringsToProcess)
            {
                foreach (var c in s)
                {
                    Move(c);
                }
            }
        }

        private IList<string> ParseRegex(string input)
        {
            input = input.TrimEnd(Chars.End).TrimStart(Chars.Start);
            var regexesToExplore = new List<RegexToExplore> { new RegexToExplore(_map.StartAddress, input) };
            foreach (var c in input)
            {

            }
        }

        private class RegexToExplore
        {
            public MatrixAddress StartAddress { get; }
            public string Path { get; }

            public RegexToExplore(MatrixAddress startAddress, string path)
            {
                StartAddress = startAddress;
                Path = path;
            }
        }

        private void Move(char c)
        {
            var move = GetMoveFunc(c);
            move();
            _map.WriteValue(Chars.Room);
            move();
            _map.WriteValue(Chars.Room);
            _rooms.Add(_map.Address);
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
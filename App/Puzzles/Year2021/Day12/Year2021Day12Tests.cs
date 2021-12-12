using System;
using System.Collections.Generic;
using App.Common.Strings;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace App.Puzzles.Year2021.Day12
{
    public class Year2021Day12Tests
    {
        [Test]
        public void Part1()
        {
            var caveSystem = new CaveSystem(Input);
            var result = caveSystem.CountPaths();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Part2()
        {
            var result = 0;

            Assert.That(result, Is.EqualTo(0));
        }

        private const string Input = @"
start-A
start-b
A-c
A-b
b-d
A-end
b-end";
    }

    public class CaveSystem
    {
        private readonly Dictionary<string, CaveConnection> _connections;

        public CaveSystem(string input)
        {
            var lines = PuzzleInputReader.ReadLines(input);
            _connections = new Dictionary<string, CaveConnection>();
            foreach (var line in lines)
            {
                var parts = line.Split('-');
                var left = parts[0];
                var right = parts[1];

                AddConnection(left, right);
                AddConnection(right, left);
            }
        }

        private void AddConnection(string from, string to)
        {
            if (!_connections.TryGetValue(from, out var connection))
            {
                connection = new CaveConnection(from);
                _connections.Add(from, connection);
            }

            connection.Links.Add(to);
        }
        
        public int CountPaths()
        {
            var initial = "start";

            var paths = FindPaths("", initial);

            return paths.Count;
        }

        private List<List<string>> FindPaths(string path, string current)
        {
            var connections = _connections[current]
        }
    }

    public class CaveConnection
    {
        public string Name { get; }
        public HashSet<string> Links { get; }

        public CaveConnection(string name)
        {
            Name = name;
            Links = new HashSet<string>();
        }
    }
}
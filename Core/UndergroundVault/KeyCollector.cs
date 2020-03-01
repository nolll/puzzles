using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Core.Tools;

namespace Core.UndergroundVault
{
    public class KeyCollector
    {
        private IList<VaultKey> _keys;
        private IList<VaultDoor> _doors;
        private Matrix<char> _matrix;
        private MatrixAddress _startAddress;
        private readonly IDictionary<string, int> _distanceCache;
        private readonly IDictionary<(char, char), VaultPath> _paths;
        private int _iterations;

        public int ShortestPath { get; private set; }

        public KeyCollector(string input)
        {
            _iterations = 0;
            _distanceCache = new Dictionary<string, int>();
            _paths = new Dictionary<(char, char), VaultPath>();
            Init(input);
            MapPaths();
        }

        public void Run()
        {
            _matrix.MoveTo(_startAddress);
            _matrix.WriteValue('.');
            ShortestPath = FindShortestPathFrom(_matrix, _keys, _doors, 1);
        }

        private int FindShortestPathFrom(Matrix<char> matrix, IList<VaultKey> keys, IList<VaultDoor> doors, int depth)
        {
            _iterations++;
            var stepCounts = new List<int>();
            var currentAddress = new MatrixAddress(matrix.Address.X, matrix.Address.Y);
            var paths = keys
                .Select(o => PathFinder.ShortestPathTo(matrix, currentAddress, o.Address))
                .Where(o => o.Any());

            if (!doors.Any())
            {
                paths = paths.OrderBy(o => o.Count).Take(1);
            }
            foreach (var path in paths)
            {
                var newMatrix = matrix.Copy();
                var stepCount = FollowPath(newMatrix, path, keys, doors, depth);
                stepCounts.Add(stepCount);
            }

            return stepCounts.Any() ? stepCounts.Min() : 0;
        }

        private int FollowPath(Matrix<char> matrix, IList<MatrixAddress> path, IList<VaultKey> keys, IList<VaultDoor> doors, int depth)
        {
            var stepCount = path.Count;
            matrix.MoveTo(path.Last());
            var keyAddress = matrix.Address;
            var key = keys.First(o => o.Address.X == keyAddress.X && o.Address.Y == keyAddress.Y);
            var keyId = key.Id;
            matrix.WriteValue('.');
            var newKeys = keys.Where(o => o.Id != keyId).ToList();
            var doorId = char.ToUpper(keyId);
            if (doors.Any(o => o.Id == doorId))
            {
                matrix.MoveTo(doors.First(o => o.Id == doorId).Address);
                matrix.WriteValue('.');
                matrix.MoveTo(keyAddress);
            }

            if (newKeys.Any())
            {
                var newDoors = doors.Where(o => o.Id != doorId).ToList();
                stepCount += FindShortestPathFrom(matrix.Copy(), newKeys, newDoors, depth + 1);
            }

            return stepCount;
        }

        private int? GetDistanceFromCache(int x1, int y1, int x2, int y2)
        {
            var key = GetCacheKey(x1, y1, x2, y2);
            if (_distanceCache.TryGetValue(key, out var distance))
                return distance;
            return null;
        }

        private void AddToDistanceCache(int x1, int y1, int x2, int y2, int value)
        {
            var key = GetCacheKey(x1, y1, x2, y2);
            _distanceCache.Add(key, value);
        }

        private string GetCacheKey(int x1, int y1, int x2, int y2)
        {
            return $"{x1}-{y1}-{x2}-{y2}";
        }

        private void Init(string input)
        {
            _keys = new List<VaultKey>();
            _doors = new List<VaultDoor>();
            _matrix = new Matrix<char>();
            var rows = input.Trim().Split('\n');
            var y = 0;
            foreach (var row in rows)
            {
                var x = 0;
                var chars = row.Trim().ToCharArray();
                foreach (var c in chars)
                {
                    var address = new MatrixAddress(x, y);
                    _matrix.MoveTo(address);
                    var charToWrite = c;

                    if (char.IsLower(c))
                    {
                        charToWrite = '.';
                        _keys.Add(new VaultKey(c, address));
                    }
                    else if (char.IsUpper(c))
                    {
                        charToWrite = '.';
                        _doors.Add(new VaultDoor(c, address));
                    }
                    else if (c == '@')
                    {
                        _startAddress = address;
                        charToWrite = '.';
                    }

                    _matrix.WriteValue(charToWrite);

                    x += 1;
                }

                y += 1;
            }
        }

        private IEnumerable<IList<MatrixAddress>> GetStartPaths()
        {
            foreach (var key in _keys)
            {
                var coords = PathFinder.ShortestPathTo(_matrix, _startAddress, key.Address);
                var blockingDoors = FindBlockingDoors(coords);
                if (!blockingDoors.Any())
                    yield return coords;
            }
        }

        private void MapPaths()
        {
            foreach (var key in _keys)
            {
                var otherKeys = _keys.Where(o => o.Id != key.Id);
                foreach (var otherKey in otherKeys)
                {
                    var coords = PathFinder.ShortestPathTo(_matrix, key.Address, otherKey.Address);
                    var blockingDoors = FindBlockingDoors(coords);
                    var keysNeeded = blockingDoors.Select(o => char.ToLower(o.Id)).ToList();
                    var path = new VaultPath(coords, keysNeeded);
                    _paths.Add((key.Id, otherKey.Id), path);
                }
            }
        }

        private IEnumerable<VaultDoor> FindBlockingDoors(IEnumerable<MatrixAddress> coords)
        {
            foreach (var coord in coords)
            {
                foreach (var door in _doors)
                {
                    if (door.Address.Equals(coord))
                    {
                        yield return door;
                    }
                }
            }
        }
    }

    public class VaultPath
    {
        public IList<MatrixAddress> Coords { get; }
        public IList<char> KeysNeeded { get; }

        public VaultPath(IList<MatrixAddress> coords, IList<char> keysNeeded)
        {
            Coords = coords;
            KeysNeeded = keysNeeded;
        }
    }
}
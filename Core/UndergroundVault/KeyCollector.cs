using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.UndergroundVault
{
    public class KeyCollector
    {
        private IList<VaultKey> _keys;
        private IList<VaultDoor> _doors;
        private Matrix<char> _matrix;
        private MatrixAddress _startAddress;
        public int ShortestPath { get; private set; }
        
        public KeyCollector(string input)
        {
            Init(input);
        }

        public void Run()
        {
            _matrix.MoveTo(_startAddress);
            _matrix.WriteValue('.');
            ShortestPath = FindShortestPathFrom(_matrix, _keys, _doors);
        }

        private static int FindShortestPathFrom(Matrix<char> matrix, IList<VaultKey> keys, IList<VaultDoor> doors)
        {
            var stepCounts = new List<int>();
            var currentAddress = new MatrixAddress(matrix.Address.X, matrix.Address.Y);
            foreach (var key in keys)
            {
                var path = PathFinder.ShortestPathTo(matrix, currentAddress, key.Address);
                if (path.Any())
                {
                    var stepCount = FollowPath(matrix.Copy(), path, keys.Where(o => o.Id != key.Id).ToList(), doors);
                    stepCounts.Add(stepCount);
                }
            }

            return stepCounts.Min();
        }

        private static int FollowPath(Matrix<char> matrix, IList<MatrixAddress> path, IList<VaultKey> keys, IList<VaultDoor> doors)
        {
            var stepCount = 0;
            foreach (var address in path)
            {
                matrix.MoveTo(address);
                stepCount++;
            }

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
                stepCount += FindShortestPathFrom(matrix.Copy(), newKeys, newDoors);
            }

            return stepCount;
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
                        _keys.Add(new VaultKey(c, address));
                        charToWrite = '.';
                    }
                    else if (char.IsUpper(c))
                    {
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
    }
}
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.UndergroundVault
{
    public class KeyCollector
    {
        private IDictionary<char, VaultKey> _keys;
        private IDictionary<char, VaultDoor> _doors;
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
            var stepCount = 0;
            while (_keys.Any())
            {
                var currentAddress = new MatrixAddress(_matrix.Address.X, _matrix.Address.Y);
                var paths = _keys.Values.Select(o => PathFinder.ShortestPathTo(_matrix, currentAddress, o.Address));

                var shortestPath = paths.Where(o => o.Any()).OrderBy(o => o.Count).First();
                foreach(var address in shortestPath)
                {
                    _matrix.MoveTo(address);
                    stepCount++;
                }

                var keyAddress = _matrix.Address;
                var key = _keys.Values.First(o => o.Address.X == keyAddress.X && o.Address.Y == keyAddress.Y);
                var keyId = key.Id;
                _matrix.WriteValue('.');
                _keys.Remove(keyId);
                var doorId = char.ToUpper(keyId);
                if (_doors.ContainsKey(doorId))
                {
                    _matrix.MoveTo(_doors[doorId].Address);
                    _doors.Remove(doorId);
                    _matrix.WriteValue('.');
                    _matrix.MoveTo(keyAddress);
                }
            }

            ShortestPath = stepCount;
        }

        private void Init(string input)
        {
            _keys = new Dictionary<char, VaultKey>();
            _doors = new Dictionary<char, VaultDoor>();
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
                        _keys.Add(c, new VaultKey(c, address));
                        charToWrite = '.';
                    }
                    else if (char.IsUpper(c))
                    {
                        _doors.Add(c, new VaultDoor(c, address));
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
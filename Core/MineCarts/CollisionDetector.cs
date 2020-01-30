using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.MineCarts
{
    public class CollisionDetector
    {
        private Matrix<char> _matrix;
        private readonly IList<MineCart> _carts;
        public string LocationOfFirstCollision { get; }

        public CollisionDetector(string input)
        {
            _carts = new List<MineCart>();
            BuildMatrixAndCarts(input);
            LocationOfFirstCollision = GetLocationOfFirstCollision();
        }

        private string GetLocationOfFirstCollision()
        {
            var crashed = false;
            string crashLocation = null;
            while (!crashed)
            {
                var orderedCarts = _carts.OrderBy(o => o.Coords.Y).ThenBy(o => o.Coords.X);
                foreach (var cart in orderedCarts)
                {
                    _matrix.MoveTo(cart.Coords);
                    _matrix.TurnTo(cart.Direction);
                    _matrix.MoveForward();
                    cart.MoveTo(_matrix.Address);
                    var val = _matrix.ReadValue();
                    cart.Turn(val);

                    crashLocation = GetCrashLocation();
                    if (crashLocation != null)
                    {
                        crashed = true;
                        break;
                    }
                }
            }

            return crashLocation;
        }

        private string GetCrashLocation()
        {
            return _carts
                .GroupBy(o => $"{o.Coords.X},{o.Coords.Y}")
                .Where(g => g.Count() > 1).Select(o => o.Key)
                .FirstOrDefault();
        }

        private void BuildMatrixAndCarts(in string input)
        {
            _matrix = new Matrix<char>();
            var rows = PuzzleInputReader.Read(input).Select(o => o.Trim('_')).ToList();
            for (var y = 0; y < rows.Count; y++)
            {
                var row = rows[y].ToCharArray();
                for (var x = 0; x < row.Length; x++)
                {
                    var c = row[x];
                    var mapChar = c;
                    var coords = new MatrixAddress(x, y);
                    if (IsCartChar(c))
                    {
                        mapChar = GetMapChar(c);
                        var direction = GetDirection(c);
                        var cart = new MineCart(coords, direction, _carts.Count);
                        _carts.Add(cart);
                    }

                    _matrix.MoveTo(x, y);
                    _matrix.WriteValue(mapChar);
                }
            }
        }

        private bool IsCartChar(in char c)
        {
            return c == CharConstants.Up || c == CharConstants.Right || c == CharConstants.Down || c == CharConstants.Left;
        }

        private char GetMapChar(in char c)
        {
            return c == CharConstants.Up || c == CharConstants.Down ? CharConstants.Vertical : CharConstants.Horizontal;
        }

        private MatrixDirection GetDirection(in char c)
        {
            if (c == CharConstants.Up)
                return MatrixDirection.Up;
            if (c == CharConstants.Right)
                return MatrixDirection.Right;
            if (c == CharConstants.Down)
                return MatrixDirection.Down;
            return MatrixDirection.Left;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.MineCarts
{
    public class CollisionDetector
    {
        private Matrix<char> _matrix;
        private IList<MineCart> _carts;
        public MatrixAddress LocationOfFirstCollision { get; private set; }
        public MatrixAddress LocationOfLastCart { get; private set; }

        public CollisionDetector(string input)
        {
            LocationOfFirstCollision = null;
            LocationOfLastCart = null;
            BuildMatrixAndCarts(input);
            RunCarts();
        }

        private void RunCarts()
        {
            while (LocationOfLastCart == null)
            {
                var cartsToMove = _carts.OrderBy(o => o.Coords.Y).ThenBy(o => o.Coords.X).ToList();
                var movedCarts = new List<MineCart>();
                while (cartsToMove.Any())
                {
                    var cart = cartsToMove.First();
                    cartsToMove.RemoveAt(0);
                    _matrix.MoveTo(cart.Coords);
                    _matrix.TurnTo(cart.Direction);
                    _matrix.MoveForward();
                    cart.MoveTo(_matrix.Address);
                    var val = _matrix.ReadValue();
                    cart.Turn(val);

                    if (HasCrashed(cartsToMove, movedCarts, _matrix.Address))
                    {
                        if(LocationOfFirstCollision == null) 
                            LocationOfFirstCollision = _matrix.Address;

                        RemoveCartAt(cartsToMove, _matrix.Address);
                        RemoveCartAt(movedCarts, _matrix.Address);
                    }
                    else
                    {
                        movedCarts.Add(cart);
                    }
                }

                _carts = movedCarts.Select(o => o).ToList();
                if (_carts.Count < 2)
                {
                    var lastCart = _carts.FirstOrDefault();
                    LocationOfLastCart = lastCart?.Coords ?? new MatrixAddress(0, 0);
                    break;
                }
            }
        }

        private bool HasCrashed(IList<MineCart> carts1, IList<MineCart> carts2, MatrixAddress coords)
        {
            return carts1.Any(cart => cart.Coords.X == coords.X && cart.Coords.Y == coords.Y)
                   || carts2.Any(cart => cart.Coords.X == coords.X && cart.Coords.Y == coords.Y);
        }

        private void RemoveCartAt(IList<MineCart> carts, MatrixAddress coords)
        {
            for (var i = 0; i < carts.Count; i++)
            {
                var cart = carts[i];
                if (cart.Coords.X == coords.X && cart.Coords.Y == coords.Y)
                {
                    carts.RemoveAt(i);
                    i--;
                }
            }
        }

        private void BuildMatrixAndCarts(in string input)
        {
            _matrix = new Matrix<char>();
            _carts = new List<MineCart>(); 
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
                        var cart = new MineCart(coords, direction);
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
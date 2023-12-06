using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;
using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201813;

public class CollisionDetector
{
    private Matrix<char> _matrix = new Matrix<char>(1, 1);
    private IList<MineCart> _carts = new List<MineCart>();
    public MatrixAddress? LocationOfFirstCollision { get; private set; }
    public MatrixAddress? LocationOfLastCart { get; private set; }

    public CollisionDetector(string input)
    {
        LocationOfFirstCollision = null;
        LocationOfLastCart = null;
        BuildMatrixAndCarts(input);
    }

    public void RunCarts()
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

    private static bool HasCrashed(IEnumerable<MineCart> carts1, IEnumerable<MineCart> carts2, MatrixAddress coords)
    {
        return carts1.Any(cart => cart.Coords.X == coords.X && cart.Coords.Y == coords.Y)
               || carts2.Any(cart => cart.Coords.X == coords.X && cart.Coords.Y == coords.Y);
    }

    private static void RemoveCartAt(IList<MineCart> carts, MatrixAddress coords)
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

    private void BuildMatrixAndCarts(string input)
    {
        var rows = InputReader.ReadLines(input).ToList();
        var width = rows.First().Length;
        var height = rows.Count();
        _matrix = new Matrix<char>(width, height);
        _carts = new List<MineCart>();
        for (var y = 0; y < height; y++)
        {
            var row = rows[y].ToCharArray();
            for (var x = 0; x < width; x++)
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

                _matrix.WriteValueAt(x, y, mapChar);
            }
        }
    }

    private static bool IsCartChar(char c)
    {
        return c is CharConstants.Up or CharConstants.Right or CharConstants.Down or CharConstants.Left;
    }

    private static char GetMapChar(char c)
    {
        return c is CharConstants.Up or CharConstants.Down ? CharConstants.Vertical : CharConstants.Horizontal;
    }

    private MatrixDirection GetDirection(char c)
    {
        return c switch
        {
            CharConstants.Up => MatrixDirection.Up,
            CharConstants.Right => MatrixDirection.Right,
            CharConstants.Down => MatrixDirection.Down,
            _ => MatrixDirection.Left
        };
    }
}
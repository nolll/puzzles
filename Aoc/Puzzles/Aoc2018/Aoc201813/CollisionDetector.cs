using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201813;

public class CollisionDetector
{
    private Grid<char> _grid = new Grid<char>(1, 1);
    private IList<MineCart> _carts = new List<MineCart>();
    public Coord? LocationOfFirstCollision { get; private set; }
    public Coord? LocationOfLastCart { get; private set; }

    public CollisionDetector(string input)
    {
        LocationOfFirstCollision = null;
        LocationOfLastCart = null;
        BuildGridAndCarts(input);
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
                _grid.MoveTo(cart.Coords);
                _grid.TurnTo(cart.Direction);
                _grid.MoveForward();
                cart.MoveTo(_grid.Coord);
                var val = _grid.ReadValue();
                cart.Turn(val);

                if (HasCrashed(cartsToMove, movedCarts, _grid.Coord))
                {
                    if(LocationOfFirstCollision == null) 
                        LocationOfFirstCollision = _grid.Coord;

                    RemoveCartAt(cartsToMove, _grid.Coord);
                    RemoveCartAt(movedCarts, _grid.Coord);
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
                LocationOfLastCart = lastCart?.Coords ?? new Coord(0, 0);
                break;
            }
        }
    }

    private static bool HasCrashed(IEnumerable<MineCart> carts1, IEnumerable<MineCart> carts2, Coord coords)
    {
        return carts1.Any(cart => cart.Coords.X == coords.X && cart.Coords.Y == coords.Y)
               || carts2.Any(cart => cart.Coords.X == coords.X && cart.Coords.Y == coords.Y);
    }

    private static void RemoveCartAt(IList<MineCart> carts, Coord coords)
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

    private void BuildGridAndCarts(string input)
    {
        var rows = StringReader.ReadLines(input).ToList();
        var width = rows.First().Length;
        var height = rows.Count();
        _grid = new Grid<char>(width, height);
        _carts = new List<MineCart>();
        for (var y = 0; y < height; y++)
        {
            var row = rows[y].ToCharArray();
            for (var x = 0; x < width; x++)
            {
                var c = row[x];
                var mapChar = c;
                var coords = new Coord(x, y);
                if (IsCartChar(c))
                {
                    mapChar = GetMapChar(c);
                    var direction = GetDirection(c);
                    var cart = new MineCart(coords, direction);
                    _carts.Add(cart);
                }

                _grid.WriteValueAt(x, y, mapChar);
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

    private GridDirection GetDirection(char c)
    {
        return c switch
        {
            CharConstants.Up => GridDirection.Up,
            CharConstants.Right => GridDirection.Right,
            CharConstants.Down => GridDirection.Down,
            _ => GridDirection.Left
        };
    }
}
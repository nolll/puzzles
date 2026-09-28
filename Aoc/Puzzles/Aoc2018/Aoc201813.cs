using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Mine Cart Madness")]
public class Aoc201813 : AocPuzzle
{
    [Puzzle("289dd4c6742ccddf660417b3b45acad3")]
    public string Part1(string input)
    {
        var detector = new CollisionDetector(input);
        detector.RunCarts();
        return detector.LocationOfFirstCollision!.Id;
    }

    [Puzzle("b4f2a42936a725f796e9f00399495d54")]
    public string Part2(string input)
    {
        var detector = new CollisionDetector(input);
        detector.RunCarts();
        return detector.LocationOfLastCart!.Id;
    }

    public class CollisionDetector
    {
        private Grid<char> _grid = new();
        private List<MineCart> _carts = [];
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
                        if (LocationOfFirstCollision == null)
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
            var rows = input.Split(LineBreaks.Single);
            var width = rows.First().Length;
            var height = rows.Length;
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

        private static bool IsCartChar(char c) =>
            c is CharConstants.Up or CharConstants.Right or CharConstants.Down or CharConstants.Left;

        private static char GetMapChar(char c) =>
            c is CharConstants.Up or CharConstants.Down ? CharConstants.Vertical : CharConstants.Horizontal;

        private static GridDirection GetDirection(char c) => c switch
        {
            CharConstants.Up => GridDirection.Up,
            CharConstants.Right => GridDirection.Right,
            CharConstants.Down => GridDirection.Down,
            _ => GridDirection.Left
        };
    }
    
    public static class CharConstants
    {
        public const char Up = '^';
        public const char Right = '>';
        public const char Down = 'v';
        public const char Left = '<';
        public const char Vertical = '|';
        public const char Horizontal = '-';
        public const char Backslash = '\\';
        public const char Slash = '/';
        public const char Plus = '+';
    }

    public class MineCart
    {
        private MineCartTurn _nextTurn;

        public Coord Coords { get; private set; }
        public GridDirection Direction { get; private set; }

        public MineCart(Coord coords, GridDirection direction)
        {
            Coords = coords;
            Direction = direction;
            _nextTurn = MineCartTurn.Left;
        }

        public void MoveTo(Coord coords)
        {
            Coords = coords;
        }

        public void Turn(in char c)
        {
            if (ShouldChangeDirection(c))
                Direction = GetDirection(c);

            if (ShouldChangeNextTurn(c))
                _nextTurn = GetNextTurn();
        }

        private bool ShouldChangeDirection(in char c)
        {
            return c == CharConstants.Backslash || c == CharConstants.Slash || c == CharConstants.Plus;
        }

        private bool ShouldChangeNextTurn(in char c)
        {
            return c == CharConstants.Plus;
        }

        private MineCartTurn GetNextTurn()
        {
            if (_nextTurn == MineCartTurn.Left)
                return MineCartTurn.Straight;
            if (_nextTurn == MineCartTurn.Straight)
                return MineCartTurn.Right;
            return MineCartTurn.Left;
        }

        private GridDirection GetDirection(in char c)
        {
            if (c == CharConstants.Backslash)
                return GetDirectionForBackslash();

            if (c == CharConstants.Slash)
                return GetDirectionForSlash();

            return GetDirectionForPlus();
        }

        private GridDirection GetDirectionForBackslash()
        {
            if (Direction.Equals(GridDirection.Up))
                return GridDirection.Left;
            if (Direction.Equals(GridDirection.Right))
                return GridDirection.Down;
            if (Direction.Equals(GridDirection.Down))
                return GridDirection.Right;
            return GridDirection.Up;
        }

        private GridDirection GetDirectionForSlash()
        {
            if (Direction.Equals(GridDirection.Up))
                return GridDirection.Right;
            if (Direction.Equals(GridDirection.Right))
                return GridDirection.Up;
            if (Direction.Equals(GridDirection.Down))
                return GridDirection.Left;
            return GridDirection.Down;
        }

        private GridDirection GetDirectionForPlus()
        {
            if (_nextTurn == MineCartTurn.Straight)
                return Direction;

            if (Direction.Equals(GridDirection.Up))
                return _nextTurn == MineCartTurn.Left ? GridDirection.Left : GridDirection.Right;

            if (Direction.Equals(GridDirection.Right))
                return _nextTurn == MineCartTurn.Left ? GridDirection.Up : GridDirection.Down;

            if (Direction.Equals(GridDirection.Down))
                return _nextTurn == MineCartTurn.Left ? GridDirection.Right : GridDirection.Left;

            return _nextTurn == MineCartTurn.Left ? GridDirection.Down : GridDirection.Up;
        }
    }
    
    public enum MineCartTurn
    {
        Left,
        Right,
        Straight
    }
}
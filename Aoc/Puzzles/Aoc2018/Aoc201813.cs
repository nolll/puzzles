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
        var (firstCollision, _) = Solve(input);
        return firstCollision;
    }

    [Puzzle("b4f2a42936a725f796e9f00399495d54")]
    public string Part2(string input)
    {
        var (_, lastCart) = Solve(input);
        return lastCart;
    }

    private static (string firstCollision, string lastCart) Solve(string input)
    {
        Coord? locationOfFirstCollision = null;
        var (grid, carts) = BuildGridAndCarts(input);
        while (true)
        {
            var cartsToMove = carts.OrderBy(o => o.Coords.Y).ThenBy(o => o.Coords.X).ToList();
            var movedCarts = new List<MineCart>();
            while (cartsToMove.Count != 0)
            {
                var cart = cartsToMove.First();
                cartsToMove.RemoveAt(0);
                grid.MoveTo(cart.Coords);
                grid.TurnTo(cart.Direction);
                grid.MoveForward();
                cart.MoveTo(grid.Coord);
                var val = grid.ReadValue();
                cart.Turn(val);

                if (HasCrashed(cartsToMove, movedCarts, grid.Coord))
                {
                    locationOfFirstCollision ??= grid.Coord;
                    RemoveCartAt(cartsToMove, grid.Coord);
                    RemoveCartAt(movedCarts, grid.Coord);
                }
                else
                {
                    movedCarts.Add(cart);
                }
            }

            carts = movedCarts.Select(o => o).ToList();
            if (carts.Count < 2)
                break;
        }

        return (locationOfFirstCollision?.Id ?? "", carts.FirstOrDefault()?.Coords.Id ?? "");
    }

    private static bool HasCrashed(IEnumerable<MineCart> carts1, IEnumerable<MineCart> carts2, Coord coords) =>
        carts1.Any(cart => cart.Coords.X == coords.X && cart.Coords.Y == coords.Y) ||
        carts2.Any(cart => cart.Coords.X == coords.X && cart.Coords.Y == coords.Y);

    private static void RemoveCartAt(IList<MineCart> carts, Coord coords)
    {
        for (var i = 0; i < carts.Count; i++)
        {
            var cart = carts[i];
            if (cart.Coords.X != coords.X || cart.Coords.Y != coords.Y)
                continue;

            carts.RemoveAt(i);
            i--;
        }
    }

    private static (Grid<char>, List<MineCart>) BuildGridAndCarts(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var width = rows.First().Length;
        var height = rows.Length;
        var grid = new Grid<char>(width, height);
        var carts = new List<MineCart>();
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
                    carts.Add(cart);
                }

                grid.WriteValueAt(x, y, mapChar);
            }
        }

        return (grid, carts);
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

    private static class CharConstants
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

    private class MineCart(Coord coords, GridDirection direction)
    {
        private MineCartTurn _nextTurn = MineCartTurn.Left;

        public Coord Coords { get; private set; } = coords;
        public GridDirection Direction { get; private set; } = direction;

        public void MoveTo(Coord coords) => Coords = coords;

        public void Turn(in char c)
        {
            if (ShouldChangeDirection(c))
                Direction = GetDirection(c);

            if (ShouldChangeNextTurn(c))
                _nextTurn = GetNextTurn();
        }

        private static bool ShouldChangeDirection(in char c) =>
            c is CharConstants.Backslash or CharConstants.Slash or CharConstants.Plus;

        private static bool ShouldChangeNextTurn(in char c) => c == CharConstants.Plus;

        private MineCartTurn GetNextTurn() => _nextTurn switch
        {
            MineCartTurn.Left => MineCartTurn.Straight,
            MineCartTurn.Straight => MineCartTurn.Right,
            _ => MineCartTurn.Left
        };

        private GridDirection GetDirection(in char c) => c switch
        {
            CharConstants.Backslash => GetDirectionForBackslash(),
            CharConstants.Slash => GetDirectionForSlash(),
            _ => GetDirectionForPlus()
        };

        private GridDirection GetDirectionForBackslash()
        {
            if (Direction == GridDirection.Up)
                return GridDirection.Left;
            if (Direction == GridDirection.Right)
                return GridDirection.Down;
            if (Direction == GridDirection.Down)
                return GridDirection.Right;
            return GridDirection.Up;
        }

        private GridDirection GetDirectionForSlash()
        {
            if (Direction == GridDirection.Up)
                return GridDirection.Right;
            if (Direction == GridDirection.Right)
                return GridDirection.Up;
            if (Direction == GridDirection.Down)
                return GridDirection.Left;
            return GridDirection.Down;
        }

        private GridDirection GetDirectionForPlus()
        {
            if (_nextTurn == MineCartTurn.Straight)
                return Direction;

            if (Direction == GridDirection.Up)
                return _nextTurn == MineCartTurn.Left ? GridDirection.Left : GridDirection.Right;

            if (Direction == GridDirection.Right)
                return _nextTurn == MineCartTurn.Left ? GridDirection.Up : GridDirection.Down;

            if (Direction == GridDirection.Down)
                return _nextTurn == MineCartTurn.Left ? GridDirection.Right : GridDirection.Left;

            return _nextTurn == MineCartTurn.Left ? GridDirection.Down : GridDirection.Up;
        }
    }

    private enum MineCartTurn
    {
        Left,
        Right,
        Straight
    }
}
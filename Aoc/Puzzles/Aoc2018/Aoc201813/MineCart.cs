using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201813;

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
        if(ShouldChangeDirection(c))
            Direction = GetDirection(c);

        if(ShouldChangeNextTurn(c))
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
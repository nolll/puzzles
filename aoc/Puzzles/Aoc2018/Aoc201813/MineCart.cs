using Common.CoordinateSystems.CoordinateSystem2D;

namespace Aoc.Puzzles.Aoc2018.Aoc201813;

public class MineCart
{
    private MineCartTurn _nextTurn;
        
    public MatrixAddress Coords { get; private set; }
    public MatrixDirection Direction { get; private set; }

    public MineCart(MatrixAddress coords, MatrixDirection direction)
    {
        Coords = coords;
        Direction = direction;
        _nextTurn = MineCartTurn.Left;
    }
    
    public void MoveTo(MatrixAddress coords)
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

    private MatrixDirection GetDirection(in char c)
    {
        if (c == CharConstants.Backslash)
            return GetDirectionForBackslash();

        if (c == CharConstants.Slash)
            return GetDirectionForSlash();

        return GetDirectionForPlus();
    }

    private MatrixDirection GetDirectionForBackslash()
    {
        if (Direction.Equals(MatrixDirection.Up))
            return MatrixDirection.Left;
        if (Direction.Equals(MatrixDirection.Right))
            return MatrixDirection.Down;
        if (Direction.Equals(MatrixDirection.Down))
            return MatrixDirection.Right;
        return MatrixDirection.Up;
    }

    private MatrixDirection GetDirectionForSlash()
    {
        if (Direction.Equals(MatrixDirection.Up))
            return MatrixDirection.Right;
        if (Direction.Equals(MatrixDirection.Right))
            return MatrixDirection.Up;
        if (Direction.Equals(MatrixDirection.Down))
            return MatrixDirection.Left;
        return MatrixDirection.Down;
    }

    private MatrixDirection GetDirectionForPlus()
    {
        if (_nextTurn == MineCartTurn.Straight)
            return Direction;

        if (Direction.Equals(MatrixDirection.Up))
            return _nextTurn == MineCartTurn.Left ? MatrixDirection.Left : MatrixDirection.Right;

        if (Direction.Equals(MatrixDirection.Right))
            return _nextTurn == MineCartTurn.Left ? MatrixDirection.Up : MatrixDirection.Down;

        if (Direction.Equals(MatrixDirection.Down))
            return _nextTurn == MineCartTurn.Left ? MatrixDirection.Right : MatrixDirection.Left;

        return _nextTurn == MineCartTurn.Left ? MatrixDirection.Down : MatrixDirection.Up;
    }
}
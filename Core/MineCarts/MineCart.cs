using Core.Tools;

namespace Core.MineCarts
{
    public class MineCart
    {
        public MatrixAddress Coords { get; private set; }
        public MatrixDirection Direction { get; private set; }
        public int Id { get; }
        private MineCartTurn _nextTurn;

        public MineCart(MatrixAddress coords, MatrixDirection direction, int id)
        {
            Coords = coords;
            Direction = direction;
            Id = id;
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

            if (c == CharConstants.Plus)
                return GetDirectionForPlus();

            return null;
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
}